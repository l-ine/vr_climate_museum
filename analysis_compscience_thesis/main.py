import os
import chardet
import pandas as pd
import numpy as np
import matplotlib.pyplot as plt
import seaborn as sns
from pandas.plotting import boxplot
from scipy import stats


def get_encoding(file):
    with open(file, 'rb') as f:
        result = chardet.detect(f.read())
    return result['encoding']

def append_csv(name1, name2):
    enc1 = get_encoding(name1)
    enc2 = get_encoding(name2)
    # append the csv files in data folder
    data1 = pd.read_csv(name1, encoding=enc1)
    data2 = pd.read_csv(name2, encoding=enc2)
    # append data1 and data2
    data = pd.concat([data1, data2])
    return data

def calculate_mean_per_participant(data, items, col_name):
    data[col_name] = data[items].mean(axis=1)
    return data


def bar_plot(data, items, title, ylabel):
    """
    data: DataFrame containing the data
    items: list of column names to plot
    title: title of the plot
    ylabel: label for the y-axis
    """
    means = [data[item].mean() for item in items]
    stds = [data[item].std() for item in items]

    x = np.arange(len(items))
    width = 0.35

    fig, ax = plt.subplots()
    rects = ax.bar(x, means, width, yerr=stds, capsize=5)

    ax.set_ylim(ymin = 0, ymax = 7)
    ax.set_ylabel(ylabel)
    ax.set_title(title)
    ax.set_xticks(x)
    ax.set_xticklabels(items)
    ax.bar_label(rects, fmt='%.2f', padding=3)

    fig.tight_layout()
    plt.show()

def my_boxplot(data, items, title, ylabel):
    """
    data: DataFrame containing the data
    items: list of column names to plot
    title: title of the plot
    ylabel: label for the y-axis
    """
    fig, ax = plt.subplots(figsize=(8, 6))
    ax.boxplot([data[item].dropna() for item in items])
    ax.set_xticklabels(items, rotation=45)
    ax.set_ylabel(ylabel)
    ax.set_title(title)
    ax.set_ylim(ymin=0, ymax=7)
    plt.tight_layout()
    plt.show()

def violin_plot(data, items, title, ylabel, save_path=None):
    """
    data: DataFrame containing the data
    items: list of column names to plot
    title: title of the plot
    ylabel: label for the y-axis
    """
    plt.figure(figsize=(8, 6))
    sns.violinplot(data=data[items], palette="muted", cut=0)
    plt.xticks(rotation=45)
    plt.ylabel(ylabel)
    plt.title(title)
    plt.tight_layout()

    if save_path:
        plt.savefig(save_path, bbox_inches='tight', dpi=300)

    plt.show()


def aggregate_scores(data, items, new_column_name):
    """
    data: DataFrame containing the data
    items: list of column names to aggregate
    new_column_name: name for the new aggregated column
    """
    data[new_column_name] = data[items].mean(axis=1)
    return data

def ttest_aggregated(data, column_name, neutral_value=4):
    """
    data: DataFrame containing the data
    column_name: name of the column with aggregated scores
    neutral_value: value to test against (default: 4)
    """
    t_stat, p_val = stats.ttest_1samp(data[column_name].dropna(), neutral_value)
    return {
        't_statistic': t_stat,
        'p_value': p_val,
        'significant': p_val < 0.05
    }


def ttest_against_neutral(data, items, neutral_value=4):
    results = {}
    for item in items:
        t_stat, p_val = stats.ttest_1samp(data[item].dropna(), neutral_value)
        results[item] = {
            't_statistic': t_stat,
            'p_value': p_val,
            'significant': p_val < 0.05
        }
    return pd.DataFrame(results).T

if __name__ == '__main__':
    # set working directory
    mydir = os.getcwd()
    data_dir = os.path.join(mydir, "data_survey\data")
    print("data dir = ", data_dir)

    # combine data sets
    survey_data = append_csv(data_dir + '\data_vrklimastudie_2025-12-10_13-44.csv', data_dir + '\data_vr_klimastudie_t1-2_2025-12-10_13-45.csv')
    survey_data.to_csv(data_dir + '\survey_data.csv')
    #print(survey_data)

    # exclude participants who did not give consent to data usage
   # drop all rows in which row["E102"] is 0
    survey_data = survey_data[survey_data["E102"] != 0]
    print(survey_data)


    # introduce new columns with useful names
    survey_data['index'] = survey_data.index
    survey_data['identification_item01'] = survey_data["D003_01"]
    survey_data['identification_item02'] = survey_data["D003_02"]
    survey_data['identification_item03'] = survey_data["D003_03"]

    survey_data['immersion_item01'] = survey_data["D001_01"]
    survey_data['immersion_item02'] = survey_data["D001_02"]
    survey_data['immersion_item03'] = survey_data["D001_03"]
    survey_data['immersion_item04'] = survey_data["D001_04"]
    survey_data['immersion_item05'] = survey_data["D002_01"]

    # Plot identification items
    identification_items = [
        'identification_item01',
        'identification_item02',
        'identification_item03'
    ]
    #bar_plot(survey_data, identification_items, 'Identification Items', 'Mean Score')
    #my_boxplot(survey_data, identification_items, 'Identification Items', 'Mean Score')
    violin_plot(survey_data, identification_items, 'Identification Items', 'Score', save_path=data_dir + '/id_plot.png')

    # calculate mean per person over all identification items
    calculate_mean_per_participant(survey_data, identification_items, 'identification_mean')
    # calculate overall mean over all persons and all identification items
    mean_id = np.mean(survey_data['identification_mean'])
    sd_id = np.std(survey_data['identification_mean'])
    print("Mean identification and standard deviation: ", mean_id, sd_id)

    # calculate mean for each item
    for item in identification_items:
        print(f"{item}:", np.mean(survey_data[item].dropna()), np.mean(survey_data[item].dropna()))

    # t-test
    id_results = ttest_against_neutral(survey_data, identification_items)
    print("Identification Items t-test Results:\n", id_results)

    # Plot immersion items
    immersion_items = [
        'immersion_item01',
        'immersion_item02',
        'immersion_item03',
        'immersion_item04',
        'immersion_item05'
    ]
    #bar_plot(survey_data, immersion_items, 'Immersion Items', 'Mean Score')
    #my_boxplot(survey_data, immersion_items, 'Immersion Items', 'Mean Score')
    violin_plot(survey_data, immersion_items, 'Immersion Items', 'Score', save_path=data_dir + '/immersion_plot.png')

    ####################
    # overall immersion
    ####################

    # calculate mean per person over all identification items
    calculate_mean_per_participant(survey_data, immersion_items, 'immersion_mean')

    # calculate overall mean over all persons and all identification items
    mean_immersion = np.mean(survey_data['immersion_mean'])
    sd_immersion = np.std(survey_data['immersion_mean'])
    print("Mean immersion and standard deviation: ", mean_immersion, sd_immersion)

    # calculate mean for each item
    for item in immersion_items:
        print(f"{item}:", np.mean(survey_data[item].dropna()), np.mean(survey_data[item].dropna()))

    # t-tests
    im_results = ttest_against_neutral(survey_data, immersion_items)
    #m_general_res = ttest_against_neutral_general(survey)
    print("\nImmersion Items t-test Results:\n", im_results)


    # Perform t-tests on aggregated scores
    id_agg_result = ttest_aggregated(survey_data, 'identification_mean')
    print("Aggregated Identification t-test Result:\n", id_agg_result)

    im_agg_result = ttest_aggregated(survey_data, 'immersion_mean')
    print("\nAggregated Immersion t-test Result:\n", im_agg_result)


    survey_data.to_csv(data_dir + '\survey_data.csv')
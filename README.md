# Virtual Reality Climate Museum

> Extending an interactive climate simulation app by VR and game features

This project provides a Unity project of a virtual reality app to explore climate change simulations and solutions using the [En-ROADS climate solutions simulator](https://www.climateinteractive.org/en-roads/ "En-ROADS climate solutions simulator"). 
It was developed as part of a master thesis project from May to December 2025, extending the existing [Interactive Climate Museum](https://github.com/cognitivemodeling/interactiveclimatemuseum "Interactive Climate Museum") project. The original project lets players explore the simulator, where adjusting the simulator's sliders results in changes of the environment surrounding the museum (sea, lake, city, trees, etc). The present VR app adds a community hall in which the player slips into a role and learns about and discusses different climate measures with a virtual town citizen.

The VR app was also tested among test users. Thus, this repository also includes a small dataset with ratings and open feedback, and a corresponding data analysis.

> **NOTE**
> 
> This repository is under construction (as of Dec 2025). Additional project files are currently and will be added soon.
> Most importantly, two relevant but large Unity scene files will soon be included in the repo.


## Usage

In order to work with the code, you need the embedded browser provided by [Vuplex WebView](https://assetstore.unity.com/packages/tools/gui/3d-webview-for-android-and-ios-web-browser-135383). The project relies on this Unity plugin to integrate the En-ROADS simulator into the scene. 
To request the temperature values used for the environmental changes, a [REST-API](https://drive.google.com/file/d/1AkiMiauTpfZKjk5UCfSSLlkWKQ4CqcD9/view?usp=sharing) is used as an electron-app. To work with the code, you need the [built electron-app](https://drive.google.com/file/d/1fb9Moa3H0JLHRSI67X5-9IaIlz7EVNWy/view?usp=sharing) in the Unity project folder *Assets/StreamingAssets*.
To map the custom 3D avatar models to the VR controllers, the [Final IK](https://assetstore.unity.com/packages/tools/animation/final-ik-14290 "Final IK plugin") plugin is used.

The entire project was developed on *Windows 11* systems for *Meta Quest 3* VR headsets.

### Unity project

For a detailed documentation of the Unity projects, contact the owner of the repository and ask for her master thesis.

### Data analysis

Run *analysis.py* to generate the descriptive statistics and figures from the dataset.

## License

[![CC0](https://licensebuttons.net/p/zero/1.0/88x31.png)](https://creativecommons.org/publicdomain/zero/1.0/)

## Acknowledgements



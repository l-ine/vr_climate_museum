using UnityEngine;
using Vuplex.WebView;
using System.Collections;

public class LoadSimulator : MonoBehaviour
{
    public CanvasWebViewPrefab webViewPrefab;
    public string url = "https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&lang=de";
    public bool isInitialized = false;
    public string[] click_element_name = { "title allow-selection svelte-1i6f4xi", "group-header svelte-1eu4b14", "graph-menu-list-item svelte-11k7u8l navigable", "title allow-selection svelte-1i6f4xi", "group-header svelte-1eu4b14", "graph-menu-list-item svelte-11k7u8l navigable" };
    public int[] click_element_id = { 0, 10, 13, 1, 0, 13 };
    public bool busy = false;
    public GameObject loadingCanvas;
    public LogData logData;

    public void Awake()
    {
        this.url = "https://en-roads.climateinteractive.org/scenario.html?v=25.11.0&lang=de";
    }

    public async void Start()
    {
        click_element_name = new string[] { "title allow-selection svelte-1i6f4xi", "group-header svelte-1eu4b14", "graph-menu-list-item svelte-11k7u8l navigable", "title allow-selection svelte-1i6f4xi", "group-header svelte-1eu4b14", "graph-menu-list-item svelte-11k7u8l navigable" };
        click_element_id = new int[] { 0, 10, 13, 1, 0, 13 };
        await webViewPrefab.WaitUntilInitialized();
        isInitialized = true;   
        //Invoke("adjustWebsiteLayout", 3.0f); 

        if (!this.busy)
        {
            
            Invoke("adjustWebsiteLayout", 3.0f);
        }
            
    }

    public void Update()
    {
        if (isInitialized && !this.busy)
        {
            if (webViewPrefab.WebView.Url != url)
            {
                
                url = webViewPrefab.WebView.Url;
                Debug.Log("LoadSimulator Update: URL changed to " + url);

                // save url, it includes the slider ids and values the player has used
                GameManager.currentUrl = url;
                logData.AddNewEntry("simulator url changed to " + url);
                
            }
        }
            
            
        
    }


    public void loadUrl(string url)
    {
        // url = https://en-roads.climateinteractive.org/scenario.html?v=25.8.0&p16=-0.05&p39=250&p373=50 // for electrification, renewables and carbon price
        //await webViewPrefab.WaitUntilInitialized();
        

        if (!this.busy)
        {
            loadingCanvas.gameObject.SetActive(true);
            this.url = url;
            webViewPrefab.WebView.LoadUrl(url);
            Invoke("adjustWebsiteLayout", 3.0f);
        }

        Debug.Log("Loading URL: " + url);

        // // Javascript (JS) function to deactive all listeners on selected element 
        // webViewPrefab.WebView.ExecuteJavaScript("function deactivateListeners(elem) {" +
        //     "var old_element = elem;" +
        //     "var new_element = old_element.cloneNode(true);" +
        //     "old_element.parentNode.replaceChild(new_element, old_element);" +
        //     "}");

        // // Javascript function to set opacity of selected element to 0.3
        // webViewPrefab.WebView.ExecuteJavaScript("function lowOpacity(elem) {return elem.style.opacity = '0.3';}");

        //Invoke("adjustTopToolbar", 2f); // wait 2 seconds before adjusting the top toolbar
        //Invoke("adjustWebsiteLayout", 2f);
    }

    public void adjustWebsiteLayout()
    {
        

        // unfortunately, we have to simulate clicks on the website via JS code to select the two graphs we want to show

        this.busy = true;
        loadingCanvas.gameObject.SetActive(true);
        adjustTopToolbar();
        for (int i = 0; i < click_element_name.Length; i++)
        {
            int idx = i; // capture loop index
            float delay = 0.2f * idx; // or use idx * 0.1f to space clicks closer together
            this.Invoke(() => SimulateClick1Left(click_element_name[idx], click_element_id[idx]), delay);
            Debug.Log("Scheduled click for element " + click_element_name[idx] + " at index " + click_element_id[idx] + " after " + delay + " seconds.");
            //this.Invoke(() => SimulateClick1Left(click_element_name[i], click_element_id[i]), (float)i);
        }

        //Invoke("adjustTopToolbar", 2f);
        //SimulateClick1Left();
        //this.Invoke("SimulateClick2Left", 0.1f);
        //Invoke("SimulateClick3Left", 0.2f);
        //// graph 2 on the right
        //Invoke("SimulateClick1Right", 0.5f);
        //Invoke("SimulateClick2Right", 0.6f);
        //Invoke("SimulateClick3Right", 0.7f);
        this.busy = false;
        Invoke("deactivateLoadingCanvas", 2.0f);
    }

    public void deactivateLoadingCanvas()
    {
        loadingCanvas.gameObject.SetActive(false);
    }


    private void SimulateClick1Left(string click_element_name, int click_element_id)
    {
        string jsCode1 = "const button1_left = document.getElementsByClassName('" + click_element_name + "')[" +
           click_element_id.ToString() + "];" +
            "if (button1_left) {" +
                "button1_left.click();" +
                 "console.log('Button " + click_element_name + " clicked');" +
            "} else {" +
                "console.log('Button not found');}";
                // +
            //"button1_left = null;";
        UnityEngine.Debug.Log("jscode:" + jsCode1);
        // Execute the JavaScript code
        webViewPrefab.WebView.ExecuteJavaScript(jsCode1);
        UnityEngine.Debug.Log("click 1 left");
    }

    //private void SimulateClick2Left()
    //{
    //    string jsCode2 = "const button2_left = document.getElementsByClassName('group-header svelte-borpsp')[0];" +
    //        "if (button2_left) {" +
    //            "button2_left.click();" +
    //             "console.log('Button 2 left clicked');" +
    //        "} else {" +
    //            "console.log('Button 2 left not found');}" +
    //        "button2_left = null;";


    //    // Execute the JavaScript code
    //    webViewPrefab.WebView.ExecuteJavaScript(jsCode2);
    //    UnityEngine.Debug.Log("click 2 left");
    //}

    //private void SimulateClick3Left()
    //{
    //    string jsCode3 = "const button3_left = document.getElementsByClassName('graph-menu-list-item svelte-11k7u8l navigable')[0];" +
    //        "if (button3_left) {" +
    //            "button3_left.click();" +
    //             "console.log('Button 3 left clicked');" +
    //        "} else {" +
    //            "console.log('Button 3 left not found');}" +
    //        "button3_left = null;";

    //    // Execute the JavaScript code
    //    webViewPrefab.WebView.ExecuteJavaScript(jsCode3);
    //    UnityEngine.Debug.Log("click 3 left");
    //}

    //private void SimulateClick1Right()
    //{
    //    string jsCode1 = "const button1_right = document.getElementsByClassName('title allow-selection svelte-zl6kcb')[1];" +
    //        "if (button1_right) {" +
    //            "button1_right.click();" +
    //             "console.log('Button 1 right clicked');" +
    //        "} else {" +
    //            "console.log('Button 1 right not found');}" +
    //        "button1_right = null;";

    //    // Execute the JavaScript code
    //    webViewPrefab.WebView.ExecuteJavaScript(jsCode1);
    //    UnityEngine.Debug.Log("click 1 right");
    //}


    //private void SimulateClick2Right()
    //{
    //    string jsCode2 = "const button2_right = document.getElementsByClassName('group-header svelte-borpsp')[0];" +
    //        "if (button2_right) {" +
    //            "button2_right.click();" +
    //             "console.log('Button 2 right clicked');" +
    //        "} else {" +
    //            "console.log('Button 2 right not found');}" +
    //        "button2_right = null;";


    //    // Execute the JavaScript code
    //    webViewPrefab.WebView.ExecuteJavaScript(jsCode2);
    //    UnityEngine.Debug.Log("click 2 right");
    //}


    //private void SimulateClick3Right()
    //{
    //    string jsCode3 = "const button3_right = document.getElementsByClassName('graph-menu-list-item svelte-11k7u8l navigable')[12];" +
    //        "if (button3_right) {" +
    //            "button3_right.click();" +
    //             "console.log('Button 3 right clicked');" +
    //        "} else {" +
    //            "console.log('Button 3 right not found');}" +
    //        "button3_right = null;";

    //    // Execute the JavaScript code
    //    webViewPrefab.WebView.ExecuteJavaScript(jsCode3);
    //    UnityEngine.Debug.Log("click 3 right");
    //}



    /**
     * auxiliary methods for the rendering of the simulator instances
     */

    // this method takes an HTML class name className and returns the first element of this class
    public string getFirstByClassName(string className)
    {
        return "document.getElementsByClassName('" + className + "')[0]";
    }

    // this method takes an HTML element name elem and hides this element
    public string hideElement(string elem)
    {
        return elem + ".style.display = 'none';";
    }


    /** 
     * this method takes an HTML element name elem, a position pos and a size px.
     * It adds a padding of size px to the HTML alement elem at defined position 
     * pos (top, bottom, left, right).
     */
    public string addPadding(string elem, string pos, int px)
    {
        string withPadding = elem;
        if (pos == "bottom")
        {
            withPadding += ".style.paddingBottom = " + "'" + px.ToString() + "px';";

        }
        else if (pos == "top")
        {
            withPadding += ".style.paddingTop = " + "'" + px.ToString() + "px';";
        }
        else if (pos == "left")
        {
            withPadding += ".style.paddingLeft = " + "'" + px.ToString() + "px';";
        }
        else if (pos == "right")
        {
            withPadding += ".style.paddingRight = " + "'" + px.ToString() + "px';";
        }
        return withPadding;
    }

    /**
     * this method takes an HTML element name elem and the integers top, right, bottom 
     * and left. It adds each a padding of defined sizes top, right, bottom and left to the 
     * respective position at elem. 
     */

    public string addPadding(string elem, int top, int right, int bottom, int left)
    {
        return elem + ".style.padding = " + "'" + top.ToString() + "px" + right.ToString() + "px" + bottom.ToString() + "px" + left.ToString() + "px';";
    }


    /**
    * this method adjusts the toolbar at the top of the simulator by hiding unnecessary buttons and adding paddings
    */

    public void adjustTopToolbar()
    {
        Debug.Log("Adjusting top toolbar of simulator");
        
        // hides initial welcome screen
        webViewPrefab.WebView.ExecuteJavaScript(hideElement("document.getElementsByClassName('bg svelte-1iedi3c')[0]"));

        // hides logo in upper left corner (needs hard-coded, dynamic name to hide)
        webViewPrefab.WebView.ExecuteJavaScript(hideElement(getFirstByClassName("logo svelte-vh01ad")));

        // hides button "share your scenario" in top right corner
        webViewPrefab.WebView.ExecuteJavaScript(hideElement(getFirstByClassName("scenario-button")));

        webViewPrefab.WebView.ExecuteJavaScript(hideElement(getFirstByClassName("menu-container svelte-1tmwhqs")));

        // hides replay button in toolbar at the top
        webViewPrefab.WebView.ExecuteJavaScript(hideElement("document.getElementsByClassName('icon-button svelte-vh01ad')[4]"));

        // hides full-screen button in toolbar at the top
        webViewPrefab.WebView.ExecuteJavaScript(hideElement("document.getElementsByClassName('icon-button svelte-vh01ad')[5]"));

        webViewPrefab.WebView.ExecuteJavaScript(hideElement("document.getElementsByClassName('icon-button svelte-vh01ad')[6]"));

        // hides logos in right lower corner
        webViewPrefab.WebView.ExecuteJavaScript(hideElement(getFirstByClassName("logo-box svelte-oagbph")));

        // adds padding at the bottom of the simulator (below sliders)
        //webViewPrefab.WebView.ExecuteJavaScript(addPadding(getFirstByClassName("bottom-content"), "bottom", 20));
    }
}

//// utility functions to invoke a method WITH parameters after x seconds
//public static class Utility
//{
//    public static void Invoke(this MonoBehaviour mb, System.Action f, float delay)
//    {
//        mb.StartCoroutine(InvokeRoutine(f, delay));
//    }
//    public static IEnumerator InvokeRoutine(System.Action f, float delay)
//    {
//        yield return new WaitForSeconds(delay);
//        f();
//    }
//}
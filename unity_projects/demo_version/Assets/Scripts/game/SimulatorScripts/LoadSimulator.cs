using UnityEngine;
using Vuplex.WebView;

public class LoadSimulator : MonoBehaviour
{
    public CanvasWebViewPrefab webViewPrefab;
    public string url;
    public bool isInitialized = false;

    public void Awake()
    {
        url = "https://en-roads.climateinteractive.org/scenario.html";
    }

    public async void Start()
    {
        await webViewPrefab.WaitUntilInitialized();
        isInitialized = true;
    }
    public void Update()
    {
        if (isInitialized)
        {
            if (webViewPrefab.WebView.Url != url)
            {
                url = webViewPrefab.WebView.Url;
                Debug.Log("LoadSimulator Update: URL changed to " + url);
            }
        }
    }


    public void loadUrl(string url)
    {
        // url = https://en-roads.climateinteractive.org/scenario.html?v=25.8.0&p16=-0.05&p39=250&p373=50 // for electrification, renewables and carbon price
        //await webViewPrefab.WaitUntilInitialized();
        this.url = url;
        webViewPrefab.WebView.LoadUrl(url);
        Debug.Log("Loading URL: " + url);

        // Javascript (JS) function to deactive all listeners on selected element 
        webViewPrefab.WebView.ExecuteJavaScript("function deactivateListeners(elem) {" +
            "var old_element = elem;" +
            "var new_element = old_element.cloneNode(true);" +
            "old_element.parentNode.replaceChild(new_element, old_element);" +
            "}");

        // Javascript function to set opacity of selected element to 0.3
        webViewPrefab.WebView.ExecuteJavaScript("function lowOpacity(elem) {return elem.style.opacity = '0.3';}");

        Invoke("adjustTopToolbar", 2f); // wait 2 seconds before adjusting the top toolbar
    }

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
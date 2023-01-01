using System.ComponentModel.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NavigationExample.Navigation;

public class NavigationManger : INavigationManger<UserControl,Button>
{
    public Dictionary<string, Tuple<UserControl, Button>> PagesDictionary { get; set; }
    public string? CurrentPageName { get; set; }
    public bool CanNavigate { get; set; }
    public Control Container { set; get; }
    public NavigationManger(Dictionary<string, Tuple<UserControl, Button>> pagesDictionary, Panel contentView) : this(contentView)
    {
        PagesDictionary = pagesDictionary ?? throw new ArgumentNullException(nameof(pagesDictionary));
    }
    public NavigationManger(Panel contectView)
    {
        PagesDictionary = new Dictionary<string, Tuple<UserControl, Button>>();
        Container = contectView;
        CanNavigate = true;
    }
    public void AddPage(UserControl pageView,Button pageButton, string pageName)
    {
        if (PagesDictionary.ContainsKey(pageName))
            return;
        pageView.Dock = DockStyle.Fill;
        PagesDictionary.Add(pageName,new Tuple<UserControl, Button>(pageView,pageButton));
    }
    public void RemovePage(string pageName)
    {
        if (!PagesDictionary.ContainsKey(pageName))
            return;
        PagesDictionary.Remove(pageName);
    }
    public void NavigateTo(string pageName)
    {
        
        if(!CanNavigate)
            return;
        if(CurrentPageName == pageName) 
            return;
        if (CurrentPageName != null)
        {
            var currentBtn = PagesDictionary[CurrentPageName].Item2!;
            if (currentBtn != null)
            {
                currentBtn.Enabled = true;
            }
        }
        var pageView = PagesDictionary[pageName!].Item1;
        var pageBtn = PagesDictionary[pageName!].Item2;
        if (pageBtn != null)
        {
            pageBtn.Enabled =false;
        }
        CurrentPageName = pageName;
        if (Container.Controls.Count > 0)
        {
            Container.Controls.RemoveAt(0);
        }
        Container.Controls.Add(pageView);

    }
}
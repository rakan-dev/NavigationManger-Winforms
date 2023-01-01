namespace NavigationExample.Navigation;

public interface INavigationManger<TView,TButton> where TView : Control where TButton : Control
{
    Dictionary<string, Tuple<TView, TButton>> PagesDictionary { set; get; }
    string? CurrentPageName { set; get; }
    bool CanNavigate { set; get; }
    Control Container { set; get; }
    void AddPage(TView pageView, TButton pageButton,string pageName);
    void RemovePage(string pageName);
    void NavigateTo(string pageName);
}
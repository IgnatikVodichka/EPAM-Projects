package pages;

import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.interactions.Actions;
import org.openqa.selenium.support.FindBy;

import java.util.List;

public class HomePage extends BasePage {

    @FindBy(id = "nav-belt")
    private WebElement header;

    @FindBy(id = "twotabsearchtextbox")
    private WebElement searchField;

    @FindBy(id = "nav-xshop")
    private WebElement mainWidgets;

    @FindBy(id = "nav-cart")
    private  WebElement cart;

    @FindBy(id = "navFooter")
    private WebElement footer;

    @FindBy(id = "glow-ingress-line2")
    private WebElement geoLocation;

    @FindBy(xpath = "//a[@id='nav-hamburger-menu']")
    private WebElement hamburgerMenu;

    @FindBy(xpath = "//a[@data-menu-id='5']")
    private WebElement electronicsSubMenu;

    @FindBy(xpath = "//a[@data-menu-id='6']")
    private WebElement computersSubMenu;

    @FindBy(xpath = "//a[text()='Headphones']")
    private WebElement headphonesSubMenu;

    @FindBy(xpath = "//a[text()='Computer Components']")
    private WebElement componentsSubMenu;

    @FindBy(xpath = "//div[@id='nav-signin-tooltip']//a[@class = 'nav-action-button']")
    private WebElement popUpSignInButton;

    @FindBy(xpath = "//a[@aria-label='Choose a language for shopping.']")
    private WebElement changeLanguage;

    @FindBy(xpath = "//div[@id='nav-flyout-icp']//span[@dir='ltr']")
    private List<WebElement> languages;

    @FindBy(xpath = "//div[@id='nav-flyout-icp']")
    private WebElement languagesPopUp;

    @FindBy(id = "nav-link-accountList")
    private WebElement navAccountAndLists;

    @FindBy(xpath = "//div[@id='nav-flyout-ya-signin']//span")
    private WebElement signInButtonInsideAccAndLists;

    @FindBy(xpath = "//a[@id='icp-touch-link-country']")
    private WebElement changeCountryButton;

    @FindBy(xpath = "//a[@id='icp-touch-link-cop']")
    private WebElement changeCurrencyButton;

    Actions action = new Actions(driver);


    public HomePage(WebDriver driver) {
        super(driver);
    }

    public void openHomePage(String url){ driver.get(url); }

    public boolean checkHeaderIsVisible(){
        return header.isDisplayed();
    }

    public boolean checkSearchFieldIsVisible(){
        return searchField.isDisplayed();
    }

    public void pressEnterSearchField(){
        searchField.sendKeys(Keys.ENTER);
    }

    public boolean checkMainWidgetsAreVisible(){
        return mainWidgets.isDisplayed();
    }

    public boolean checkCartIsVisible(){
        return cart.isDisplayed();
    }

    public boolean checkFooterIsVisible(){
        return footer.isDisplayed();
    }

    public boolean checkGeoLocationContainsCorrectCountry(final String location){ return geoLocation.getText().contains(location); }

    public void clickHamburgerMenu(){
        hamburgerMenu.click();
    }

    public void clickElectronicsSubMenu(){
        electronicsSubMenu.click();
    }

    public void clickComputersSubMenu(){ computersSubMenu.click(); }

    public WebElement getComputersSubMenu(){ return computersSubMenu; }

    public void clickComponentsSubMenu (){
        componentsSubMenu.click();
    }

    public WebElement getComponentsSubMenu(){
        return componentsSubMenu;
    }

    public void clickHeadphonesSubMenu(){
        headphonesSubMenu.click();
    }

    public WebElement getHeadphonesSubMenu() {
        return headphonesSubMenu;
    }

    public void clickPopUpSignInButton(){
        popUpSignInButton.click();
    }

    public void hoverOverChangeLanguage(){
        action.moveToElement(changeLanguage).perform();
    }

    public WebElement getLanguagesPopUp(){
        return languagesPopUp;
    }

    public void hoverOverLanguageAndClick(WebElement language){
        action.moveToElement(language).click().perform();
    }

    public void hoverOverNavAccountAndLists(){
        action.moveToElement(navAccountAndLists).perform();
    }

    public String getTextOfSignInButtonInsideAccAndLists(){
        return signInButtonInsideAccAndLists.getText();
    }

    public void scrollToAndClickChangeCountry() {
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", changeCountryButton);
        changeCountryButton.click();
    }

    public void scrollToAndClickChangeCurrency() {
        ((JavascriptExecutor) driver).executeScript("arguments[0].scrollIntoView(true);", changeCurrencyButton);
        changeCurrencyButton.click();
    }

    public void enterInSearchField(final String keyword) {
        searchField.clear();
        searchField.sendKeys(keyword);
    }

    public WebElement getLanguage(final String language) {
        for(WebElement lang : languages) {
            if(lang.getText().contains(language)) {
                return lang;
            }
        }
        return null;
    }
}

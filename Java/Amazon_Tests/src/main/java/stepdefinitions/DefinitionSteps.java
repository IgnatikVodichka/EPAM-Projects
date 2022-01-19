package stepdefinitions;

import io.cucumber.java.After;
import io.cucumber.java.Before;
import io.cucumber.java.en.And;
import manager.PageFactoryManager;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import pages.*;

import java.util.ArrayList;

import static io.github.bonigarcia.wdm.WebDriverManager.chromedriver;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class DefinitionSteps {

    private static final long DEFAULT_TIME = 60;

    WebDriver driver;
    HomePage homePage;
    SearchResultsPage searchResultsPage;
    CategoryPage categoryPage;
    ProductItemPage productItemPage;
    SignInPage signInPage;
    RegistrationPage registrationPage;
    CountryPage countryPage;
    AnotherCountriesHomePage anotherCountriesHomePage;
    SettingsPage settingsPage;
    PageFactoryManager pageFactoryManager;

    @Before
    public void testsSetUp() {
        chromedriver().driverVersion("96").setup(); // I need specific chromedriver for my Browser
        ChromeOptions options = new ChromeOptions();
        options.setBinary("/Applications/BraveBrowser.app/Contents/MacOS/Brave Browser"); // Path to my browser app
        driver = new ChromeDriver(options);
        pageFactoryManager = new PageFactoryManager(driver);
    }

    @After
    public  void tearDown() { driver.quit(); }

    @And("User opens Home page {string}")
    public void openHomePage(final String url) {
        homePage = pageFactoryManager.getHomePage();
        homePage.openHomePage(url);
    }

    @And("Home page is loaded")
    public void homepageIsLoaded() {
        homePage = pageFactoryManager.getHomePage();
        homePage.waitForPageLoadComplete(DEFAULT_TIME);
    }

    @And("User checks header is visible")
    public void checksHeaderIsVisible() { assertTrue(homePage.checkHeaderIsVisible()); }

    @And("User checks search field is visible")
    public void checksSearchFieldIsVisible() { assertTrue(homePage.checkSearchFieldIsVisible()); }

    @And("User checks main widgets are visible")
    public void checksMainWidgetsAreVisible() {
        assertTrue(homePage.checkMainWidgetsAreVisible());
    }

    @And("User checks cart is visible")
    public void checksCartIsVisible() {
        assertTrue(homePage.checkCartIsVisible());
    }

    @And("User checks footer is visible")
    public void checksFooterIsVisible() {
        assertTrue(homePage.checkFooterIsVisible());
    }

    @And("User enters keyword {string} into search input")
    public void entersKeywordIntoSearchInput(final String keyword) {
        homePage.enterInSearchField(keyword);
    }

    @And("User presses ENTER button to search")
    public void pressesEnterButtonToSearch() {
        homePage.pressEnterSearchField();
    }

    @And("User checks that search keyword {string} is in current URL")
    public void checksThatSearchResultsAreContainedInCurrentURL(final String keyword) {
        searchResultsPage = pageFactoryManager.getSearchResultsPage();
        searchResultsPage.waitForPageLoadComplete(DEFAULT_TIME);
        assertTrue(driver.getCurrentUrl().contains(keyword));
    }

    @And("User checks that search results contain correct products names from keyword {string}")
    public void checksThatSearchResultsContainCorrectExpectedWord(final String keyword) {
        searchResultsPage = pageFactoryManager.getSearchResultsPage();
        var searchList = searchResultsPage.getSearchResultsListForKeyword();
        for(WebElement item : searchList){
            assertTrue(item.getText().contains(keyword));
        }
    }

    @And("User checks that search results contain correct amount {string} of products")
    public void checksThatSearchResultsContainCorrectAmountOfProducts(final String expectedAmount) {
        assertEquals(Integer.toString(searchResultsPage.getSearchResultsListForKeyword().size()), expectedAmount);
    }

    @And("User checks location {string} is correct")
    public void checksLocationIsCorrect(final String location) {
        assertTrue(homePage.checkGeoLocationContainsCorrectCountry(location));
    }

    @And("User checks that first item has correct shipping {string} location")
    public void checksThatFirstItemHasCorrectShippingLocation(final String shipping) {
        searchResultsPage = pageFactoryManager.getSearchResultsPage();
        assertTrue(searchResultsPage.getFirstSearchElement().contains(shipping));
    }

    @And("User clicks the All menu")
    public void clicksTheAllMenu() {
        homePage.clickHamburgerMenu();
    }

    @And("User clicks on electronics sub-menu")
    public void clicksOnElectronicsSubMenu() {
        homePage.clickElectronicsSubMenu();
    }

    @And("User clicks on headphones sub-menu")
    public void clicksOnHeadphonesSubMenu() {
        homePage.waitVisibilityOfElement(DEFAULT_TIME, homePage.getHeadphonesSubMenu());
        homePage.clickHeadphonesSubMenu();
    }

    @And("User chooses TOZO brand checkbox for filtering")
    public void choosesTOZOCheckboxForFiltering() {
        categoryPage = pageFactoryManager.getCategoryPage();
        categoryPage.waitForPageLoadComplete(DEFAULT_TIME);
        categoryPage.chooseCheckbox();
    }

    @And("User clicks on first item after filtering")
    public void clicksOnFirstItemAfterFiltering() {
        categoryPage.clickFirstProductItem();
    }

    @And("User clicks add to cart button")
    public void clicksAddToCartButton() {
        productItemPage = pageFactoryManager.getProductItemPage();
        productItemPage.waitForPageLoadComplete(DEFAULT_TIME);
        productItemPage.clickAddToCartButton();
    }

    @And("User checks items count {string} in the cart")
    public void checksItemsCountInTheCart(final String cartItemsCount) {
        productItemPage.waitVisibilityOfElement(DEFAULT_TIME, productItemPage.getCartSidePanel());
        assertEquals(productItemPage.getCartItemsCountText(),cartItemsCount);
    }

    @And("User clicks on cart")
    public void clicksCart() {
        productItemPage.clickOnCart();
    }

    @And("User clicks on SignIn button")
    public void clicksOnSignInButton() {
        homePage.clickPopUpSignInButton();
    }

    @And("User enters wrong email {string} and submits")
    public void entersWrongEmailAndSubmits(final String wrongEmail) {
        signInPage = pageFactoryManager.getSignInPage();
        signInPage.enterEmail(wrongEmail);
    }

    @And("User checks if alert message displayed")
    public void checksIfAlertMessageDisplayed() {
        assertTrue(signInPage.checkErrorAlertMessageIsDisplayed());
    }

    @And("User clicks on create account button")
    public void clicksOnCreateAccountButton() {
        signInPage = pageFactoryManager.getSignInPage();
        signInPage.clickCreateAccountButton();
    }

    @And("User enters name {string}")
    public void entersName(final String name) {
        registrationPage = pageFactoryManager.getRegistrationPage();
        registrationPage.inputName(name);
    }

    @And("User enters email {string}")
    public void entersEmail(final String email) {
        registrationPage.inputEmail(email);
    }

    @And("User enters password {string}")
    public void entersPassword(final String password) {
        registrationPage.inputPassword(password);
    }

    @And("User enters wrong confirmation password {string}")
    public void entersConfirmationPassword(final String confirmationPassword) {
        registrationPage.inputConfirmationPassword(confirmationPassword);
    }

    @And("User clicks on continue button")
    public void clicksOnContinueButton() {
        registrationPage.clickContinueButton();
    }

    @And("User checks that alert {string} is displayed")
    public void checksThatFormIsNotSubmitted(final String alert) {
        assertTrue(registrationPage.getAlertPasswordMissMatch().isDisplayed());
        assertTrue(registrationPage.getAlertPasswordMissMatch().getText().contains(alert));
    }

    @And("User hovers over the flag in the header to change language")
    public void hoversOverTheFlagInTheHeaderToChangeLanguage() {
        homePage.hoverOverChangeLanguage();
    }

    @And("User chooses the {string}")
    public void choosesTheLanguage(final String language) {
        homePage.waitVisibilityOfElement(DEFAULT_TIME, homePage.getLanguagesPopUp());
        homePage.waitVisibilityOfElement(DEFAULT_TIME, homePage.getLanguage(language));
        homePage.hoverOverLanguageAndClick(homePage.getLanguage(language));
    }

    @And("User hovers over Accounts & Lists")
    public void hoversOverAccountsLists() {
        homePage.waitForPageLoadComplete(DEFAULT_TIME);
        homePage.hoverOverNavAccountAndLists();
    }

    @And("User checks that sign in button text is translated {string}")
    public void checksThatSignInButtonTextIsTranslated(final String translated) {
        assertEquals(homePage.getTextOfSignInButtonInsideAccAndLists(),translated);
    }

    @And("User scrolls down and clicks change Country button")
    public void scrollsDownAndClicksChangeCountryButton() {
        homePage.waitForPageLoadComplete(DEFAULT_TIME);
        homePage.scrollToAndClickChangeCountry();
    }

    @And("User chooses country {string}")
    public void choosesCountry(final String country) {
        countryPage = pageFactoryManager.getCountryPage();
        countryPage.waitForPageLoadComplete(DEFAULT_TIME);
        countryPage.chooseCountry(country);
        countryPage.closeDropDown();
    }

    @And("User clicks to go to web-site of that country")
    public void clicksToGoToWebSiteOfThatCountry() {
        countryPage.clickGoToCountriesWebSiteButton();
    }

    @And("User switches to new tab")
    public void switchesToNewTab() {
        ArrayList<String> tabs = new ArrayList<String> (driver.getWindowHandles());
        driver.switchTo().window(tabs.get(1));
    }

    @And("User checks that flag of the country {string} is displayed on the page")
    public void checksThatFlagOfTheCountryIsDisplayedOnThePage(final String countryFlag) {
        anotherCountriesHomePage = pageFactoryManager.getCanadianHomePage();
        assertTrue(anotherCountriesHomePage.getNavCountryFlagCLass().contains(countryFlag));
    }

    @And("User scrolls down to bottom and clicks Change currency button")
    public void scrollsDownToBottomAndClicksChangeCurrencyButton() {
        homePage.scrollToAndClickChangeCurrency();
    }

    @And("User choose another currency type {string}")
    public void chooseAnotherCurrencyType(final String currencyCode) {
        settingsPage = pageFactoryManager.getSettingsPage();
        settingsPage.chooseCurrency(currencyCode);
    }

    @And("User clicks button save changes")
    public void clicksButtonSaveChanges() {
        settingsPage.clickSaveChangesButton();
    }

    @And("User clicks on Computers sub-menu")
    public void clicksOnComputersSubMenu() {
        homePage.waitVisibilityOfElement(DEFAULT_TIME, homePage.getComputersSubMenu());
        homePage.clickComputersSubMenu();
    }

    @And("User clicks on Computer Components sub-menu")
    public void clicksOnComputerComponentsSubMenu() {
        homePage.waitVisibilityOfElement(DEFAULT_TIME, homePage.getComponentsSubMenu());
        homePage.clickComponentsSubMenu();
    }

    @And("User checks that all prices contain currency type {string}")
    public void checksThatAllPricesContainCurrencyCode(final String currencyCode) {
        searchResultsPage = pageFactoryManager.getSearchResultsPage();
        searchResultsPage.waitForPageLoadComplete(DEFAULT_TIME);
        var currencyCodes = searchResultsPage.getPriceSymbolTagList();
        for (WebElement currency : currencyCodes){
            assertEquals(currency.getText(), currencyCode);
        }
    }
}

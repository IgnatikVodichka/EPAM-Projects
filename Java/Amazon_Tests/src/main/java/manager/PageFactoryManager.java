package manager;

import org.openqa.selenium.WebDriver;
import pages.*;

public class PageFactoryManager {

    WebDriver driver;

    public PageFactoryManager(WebDriver driver) {
        this.driver = driver;
    }

    public HomePage getHomePage() {
        return new HomePage(driver);
    }

    public SearchResultsPage getSearchResultsPage() {
        return new SearchResultsPage(driver);
    }

    public CategoryPage getCategoryPage() {
        return new CategoryPage(driver);
    }

    public ProductItemPage getProductItemPage(){ return new ProductItemPage(driver); }

    public SignInPage getSignInPage(){ return new SignInPage(driver); }

    public RegistrationPage getRegistrationPage() { return new RegistrationPage(driver); }

    public CountryPage getCountryPage() { return new CountryPage(driver); }

    public AnotherCountriesHomePage getCanadianHomePage() { return new AnotherCountriesHomePage(driver); }

    public SettingsPage getSettingsPage() { return new SettingsPage(driver); }
}

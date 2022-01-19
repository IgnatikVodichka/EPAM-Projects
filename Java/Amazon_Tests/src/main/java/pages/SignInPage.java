package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class SignInPage extends BasePage {

    @FindBy(xpath = "//input[@type='email']")
    private WebElement emailField;

    @FindBy(xpath = "//div[@class='a-box-inner a-alert-container']/h4")
    private WebElement errorAlert;

    @FindBy(id = "createAccountSubmit")
    private WebElement createAccountButton;

    public SignInPage(WebDriver driver) {
        super(driver);
    }

    public boolean checkErrorAlertMessageIsDisplayed(){
        return errorAlert.isDisplayed();
    }

    public void clickCreateAccountButton(){
        createAccountButton.click();
    }

    public void enterEmail(final String email) {
        emailField.clear();
        emailField.sendKeys(email);
        emailField.submit();
    }
}

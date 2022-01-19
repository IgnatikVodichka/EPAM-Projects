package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class RegistrationPage extends BasePage {

    @FindBy(xpath = "//input[@id='ap_customer_name']")
    private WebElement nameInput;

    @FindBy(xpath = "//input[@id='ap_email']")
    private WebElement emailInput;

    @FindBy(xpath = "//input[@id='ap_password']")
    private WebElement passwordInput;

    @FindBy(xpath = "//input[@id='ap_password_check']")
    private WebElement passwordConfirmationInput;

    @FindBy(id = "continue")
    private WebElement continueButton;

    @FindBy(id = "auth-password-mismatch-alert")
    private WebElement alertPasswordMissMatch;


    public RegistrationPage(WebDriver driver) {
        super(driver);
    }

    public void inputName(final String name){
        nameInput.sendKeys(name);
    }

    public void inputEmail(final String email){
        emailInput.sendKeys(email);
    }

    public void inputPassword(final String password){
        passwordInput.sendKeys(password);
    }

    public void inputConfirmationPassword(final String confirmationPassword){ passwordConfirmationInput.sendKeys(confirmationPassword); }

    public void clickContinueButton(){
        continueButton.click();
    }

    public WebElement getAlertPasswordMissMatch(){
        return alertPasswordMissMatch;
    }
}

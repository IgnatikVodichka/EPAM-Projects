package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

public class ProductItemPage extends BasePage {

    @FindBy(xpath = "//input[@aria-labelledby='mbc-buybutton-addtocart-1-announce']")
    private WebElement addToCartButton;

    @FindBy(xpath = "//span[@id='nav-cart-count']")
    private WebElement cartItemsCount;

    @FindBy(id = "nav-cart")
    private  WebElement cart;

    @FindBy(id = "ewc-content")
    private WebElement cartSidePanel;


    public ProductItemPage(WebDriver driver) {
        super(driver);
    }

    public void clickAddToCartButton() {
        addToCartButton.click();
    }

    public String getCartItemsCountText(){
        return cartItemsCount.getText();
    }

    public void clickOnCart(){
        cart.click();
    }

    public WebElement getCartSidePanel(){
        return cartSidePanel;
    }
}

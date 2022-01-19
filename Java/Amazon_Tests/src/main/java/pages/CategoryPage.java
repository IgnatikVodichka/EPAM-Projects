package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

import java.util.List;

public class CategoryPage extends BasePage {

    @FindBy(xpath = "//span[text()='TOZO']")
    private WebElement checkboxTOZO;

    @FindBy(xpath = "//div[@class='a-section a-spacing-medium']")
    private List<WebElement> searchResultsListAfterFilterApplied;


    public CategoryPage(WebDriver driver) {
        super(driver);
    }

    public void chooseCheckbox() { checkboxTOZO.click(); }

    public void clickFirstProductItem(){
        searchResultsListAfterFilterApplied.get(0).click();
    }
}

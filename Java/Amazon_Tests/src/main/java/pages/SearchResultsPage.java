package pages;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.FindBy;

import java.util.List;


public class SearchResultsPage extends BasePage {

    @FindBy(xpath = "//span[@class='a-size-medium a-color-base a-text-normal' and contains(text(),'MacBook')]")
    private List<WebElement> searchResultsListForKeyword;

    @FindBy(xpath = "//div[@class='s-include-content-margin s-latency-cf-section s-border-bottom s-border-top']")
    private List<WebElement> searchResultsList;

    @FindBy(xpath = "//div[@class='a-section a-spacing-medium']//span[@class='a-price-symbol']")
    private List<WebElement> priceSymbolTagList;


    public SearchResultsPage(WebDriver driver) { super(driver); }

    public List<WebElement> getSearchResultsListForKeyword() { return searchResultsListForKeyword; }

    public  String getFirstSearchElement(){
        return searchResultsList.get(0).getText();
    }

    public List<WebElement> getPriceSymbolTagList(){
        return priceSymbolTagList;
    }
}

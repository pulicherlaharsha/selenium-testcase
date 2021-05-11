using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

class Program
{    
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
        driver.Manage().Window.Maximize();

        driver.FindElement(By.ClassName("ico-login")).Click();
        Console.WriteLine("clicked on login button");

        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
        Console.WriteLine("input user credentials");
        driver.FindElement(By.Id("Email")).Click();
        driver.FindElement(By.Id("Email")).SendKeys("testdemowebshop@gmail.com");

        driver.FindElement(By.Id("Email")).SendKeys(Keys.Tab);

        Console.WriteLine("input password");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'Password')]")));
        driver.FindElement(By.XPath("//*[contains(@id,'Password')]")).Click();
        driver.FindElement(By.XPath("//*[contains(@id,'Password')]")).SendKeys("Test123");

        Console.WriteLine("locate and click login button");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@value,'Log in')]")));
        driver.FindElement(By.XPath("//*[contains(@value,'Log in')]")).Click();

        Console.WriteLine("locate and click books from header menu");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class,'header-menu')]/ul[1]/li[1]")));
        driver.FindElement(By.XPath("//*[contains(@class,'header-menu')]/ul[1]/li[1]")).Click();

        Console.WriteLine("locate and click first product id 13");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class, 'product-item') and contains(@data-productid,'13')]/div[1]")));
        driver.FindElement(By.XPath("//*[contains(@class, 'product-item') and contains(@data-productid,'13')]/div[1]")).Click();

        Console.WriteLine("locate and click quantity input field & clear the default value");
        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("addtocart_13.EnteredQuantity")));
        driver.FindElement(By.Name("addtocart_13.EnteredQuantity")).Click();
        driver.FindElement(By.Name("addtocart_13.EnteredQuantity")).Clear();
        driver.FindElement(By.Name("addtocart_13.EnteredQuantity")).SendKeys("2");

        Console.WriteLine("locate and click add to cart button");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'add-to-cart-button-13')]")));
        driver.FindElement(By.XPath("//*[contains(@id,'add-to-cart-button-13')]")).Click();

        Console.WriteLine("wait untill product get added to cart");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'The product has been added to your ')]/parent::*")));
        driver.FindElement(By.XPath("//*[contains(@id,'topcartlink')]/child::*")).Click();

        Console.WriteLine("locate and click agree terms n conditions");
        wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[contains(@id,'termsofservice')]")));
        driver.FindElement(By.XPath("//*[contains(@id,'termsofservice')]")).Click();

        Console.WriteLine("click the checkout button");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'checkout')]")));
        driver.FindElement(By.XPath("//*[contains(@id,'checkout')]")).Click();

        Console.WriteLine("looking for checkout page is rendered or not");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'checkout-steps')]")));
        Console.WriteLine("click on shipping address to select address from list");
        driver.FindElement(By.XPath("//*[contains(@id,'billing-address-select')]")).Click();

        Console.WriteLine("perform tab actions to select the different address than default address");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'billing-address-select')]/option[2]")));
        driver.FindElement(By.XPath("//*[contains(@id,'billing-address-select')]/option[2]")).Click();

        Console.WriteLine("new address is selected from address' list");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@onclick,'Billing.save()')]")));
        driver.FindElement(By.XPath("//*[contains(@onclick,'Billing.save()')]")).Click();

        Console.WriteLine("click on shipping address dropdown");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'shipping-address-select')]")));
        driver.FindElement(By.XPath("//*[contains(@id,'shipping-address-select')]")).Click();

        Console.WriteLine("perform tab actions to select the different address than default address in shipping address tab");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@onclick,'Shipping.save()')]")));
        driver.FindElement(By.XPath("//*[contains(@onclick,'Shipping.save()')]")).Click();

        Console.WriteLine("wait untill shipping method next day air element is visible");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@value,'Next Day Air___Shipping.FixedRate')]")));
        driver.FindElement(By.XPath("//*[contains(@value,'Next Day Air___Shipping.FixedRate')]")).Click();

        Console.WriteLine("locate and click continue button on shipping method tab");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@onclick,'ShippingMethod.save()')]")));
        driver.FindElement(By.XPath("//*[contains(@onclick,'ShippingMethod.save()')]")).Click();

        Console.WriteLine("wait until COD option is visible");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@id,'paymentmethod_0')]")));
        driver.FindElement(By.XPath("//*[contains(@id,'paymentmethod_0')]")).Click();

        Console.WriteLine("locate and click continue button on payment method tab");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@onclick,'PaymentMethod.save()')]")));
        driver.FindElement(By.XPath("//*[contains(@onclick,'PaymentMethod.save()')]")).Click();

        Console.WriteLine("locate the p tag on payent information tab");
        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'You will pay by COD')]")));
        driver.FindElement(By.XPath("//*[contains(@onclick,'PaymentInfo.save()')]")).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(@class,'order-review-data')]")));
        Console.WriteLine("Order is reviewed and placed, click on confirm button");
        driver.FindElement(By.XPath("//*[contains(@onclick,'ConfirmOrder.save()')]")).Click();

        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), 'Your order has been successfully processed!')]/parent::*")));
        driver.FindElement(By.XPath("//*[contains(@onclick,'setLocation')]")).Click();
        Console.WriteLine("order is placed successfully");

        driver.FindElement(By.XPath("//*[contains(@class,'ico-logout')]")).Click();
        Console.WriteLine("locate and click logout button & quit the browser window");

        driver.Quit();

    }
}

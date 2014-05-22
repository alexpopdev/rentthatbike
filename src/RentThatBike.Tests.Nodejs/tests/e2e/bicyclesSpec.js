describe('Bicycles page', function () {
    beforeEach(function () {
        //login
        var ptor = protractor.getInstance();
        var driver = ptor.driver;
        driver.get('http://localhost:61803/');
        
        var loginButton = driver.findElement(protractor.By.className('btn'));
        loginButton.click();

        //navigate to desired page
        browser.get('http://localhost:61803/#/bicycles');
    });

    it('should display the correct title', function () {

        var title = element(by.css('.col-md-12 h1'));

        expect(title.getText()).toEqual('Bicycles');
    });

    it('should display the logged on user details', function () {
     
        var displayName = element(by.binding('serverSideData.userDisplayName'));
        
        expect(displayName.getText()).toEqual('Admin User(admin@rentthatbike.com)');
    });
});
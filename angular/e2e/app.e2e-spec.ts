﻿import { iDrivePage } from './app.po';
import { browser, element, by } from 'protractor';

describe('abp-zero-template App', () => {
    let page: iDrivePage;

    beforeEach(() => {
        page = new iDrivePage();

        browser.driver.manage().deleteAllCookies();

        // Disable waitForAngularEnabled, otherwise test browser will be closed immediately
        browser.waitForAngularEnabled(false);
    });

    it('should login as host admin', async () => {
        // To make username div visible. It is not visible in small size screens
        browser.driver.manage().window().setSize(1200, 1000);

        await page.loginAsHostAdmin();

        await page.waitForItemToBeVisible(element(by.css('.m-topbar__username')));

        let username = await page.getUsername();
        expect(username.toUpperCase()).toEqual('\\ADMIN');

        let tenancyName = await page.getTenancyName();
        expect(tenancyName).toEqual('\\');
    });

    it('should login as default tenant admin', async () => {
        // To make username div visible. It is not visible in small size screens
        browser.driver.manage().window().setSize(1200, 1000);

        await page.loginAsTenantAdmin();

        await page.waitForItemToBeVisible(element(by.css('.m-topbar__username')));

        let username = await page.getUsername();
        expect(username.toUpperCase()).toEqual('DEFAULT\\ADMIN');

        let tenancyName = await page.getTenancyName();
        expect(tenancyName.toLocaleLowerCase()).toEqual('default\\');
    });
});

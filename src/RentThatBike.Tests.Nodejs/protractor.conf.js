exports.config = {
    // The address of a running selenium server.
    seleniumAddress: 'http://localhost:4444/wd/hub',

    // Capabilities to be passed to the webdriver instance.
    capabilities: {
        'browserName': 'chrome',
        'chromeOptions': {
            'args': ['window-size=1024,768']
        }
    },

    // Spec patterns are relative to the location of the spec file. They may
    // include glob patterns.
    specs: ['tests/e2e/**/*Spec.js'],

    // Options to be passed to Jasmine-node.
    jasmineNodeOpts: {
        showColors: true, // Use colors in the command line report.
    }
};
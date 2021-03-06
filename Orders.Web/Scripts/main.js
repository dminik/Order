﻿require.config({
    baseUrl: "/Scripts/app",    
    paths: {
        jquery: "../lib/jquery-1.8.2",
        jqueryValidate: "../lib/jquery.validate",
        jqueryValidateUnobtrusive: "../lib/jquery.validate.unobtrusive",
        ko: "../lib/knockout-2.2.0"        
    },
    shim: {
        jqueryValidate: ["jquery"],
        jqueryValidateUnobtrusive: ["jquery", "jqueryValidate"]        
    }
});
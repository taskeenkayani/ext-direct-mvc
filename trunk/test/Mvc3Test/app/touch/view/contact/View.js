Ext.define('Test.view.contact.View', {
    extend: 'Ext.Container',
    xtype: 'contact-view',
    
    config: {
        title: 'Information',
        cls: 'contact-info',
        styleHtmlContent: true,
        tpl: [
            '<h3>{FirstName} {LastName}</h3>',
            '<div><span class="label">Email: </span><a href="mailto:{Email}">{Email}</a></div>',
            '<div><span class="label">Birth Date: </span>{BirthDate:date("F j, Y")}</div>'
        ].join(''),
        items: [{
            xtype: 'component',
            top: 15,
            right: 15,
            width: 30,
            height: 30,
            style: 'background-color:red;'
        }]
    }
});
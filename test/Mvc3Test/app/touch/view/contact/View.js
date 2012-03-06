Ext.define('Test.view.contact.View', {
    extend: 'Ext.Container',
    xtype: 'contact-view',
    
    requires: 'Test.ux.Star',
    
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
            xtype: 'star',
            top: 15,
            right: 15
        }]
    }
});
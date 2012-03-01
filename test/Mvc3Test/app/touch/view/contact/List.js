Ext.define('Test.view.contact.List', {
    extend: 'Ext.dataview.List',
    xtype: 'contact-list',
    
    config: {
        title: 'Contacts',
        store: 'Contacts',
        itemTpl: '{FirstName} {LastName}'
    }
});
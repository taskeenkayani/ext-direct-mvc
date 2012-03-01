Ext.define('Test.store.Contacts', {
    extend: 'Ext.data.Store',

    config: {
        model: 'Test.model.Contact',
        proxy: {
            type: 'direct',
            directFn: Contact.List
        },
        sorters: ['FirstName', 'LastName'],
        autoLoad: true
    }
});
Ext.define('Demo.store.Contacts', {
    extend: 'Ext.data.Store',

    config: {
        model: 'Demo.model.Contact',
        proxy: {
            type: 'direct',
            directFn: Contact.List
        },
        sorters: ['FirstName', 'LastName'],
        autoLoad: true
    }
});
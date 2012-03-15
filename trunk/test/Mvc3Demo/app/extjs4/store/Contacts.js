Ext.define('Demo.store.Contacts', {
    extend: 'Ext.data.Store',
    model: 'Demo.model.Contact',
    proxy: {
        type: 'direct',
        directFn: Contact.List,
        paramOrder: 'start|limit',
        reader: {
            type: 'json',
            root: 'data'
        }
    },
    pageSize: 10,
    autoLoad: true
});
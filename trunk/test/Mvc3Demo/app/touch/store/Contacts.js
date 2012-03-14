Ext.define('Demo.store.Contacts', {
    extend: 'Ext.data.Store',

    config: {
        model: 'Demo.model.Contact',
        proxy: {
            type: 'direct',
            directFn: Contact.List,
            paramOrder: 'start|limit',
            reader: {
                type: 'json',
                rootProperty: 'data'
            }
        },
        pageSize: 20,
        sorters: ['FirstName', 'LastName'],
        grouper: function (record) {
            return record.get('FirstName')[0];
        }
    }
});
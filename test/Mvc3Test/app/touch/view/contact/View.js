Ext.define('Test.view.contact.View', {
    extend: 'Ext.Container',
    xtype: 'contact-view',
    
    config: {
        title: 'Information',
        
        items: [
            {
                xtype: 'component',
                itemId: 'content',
                tpl: [
                    '<div>{FirstName} {LastName}</div>',
                    '<div>{Email}</div>'
                ].join('')
            }
        ],
        
        record: null
    },
    
    setRecord: function (record) {
        if (record) {
            this.down('#content').setData(record.data);
        }
    }
});
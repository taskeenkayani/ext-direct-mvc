Ext.define('Test.view.contact.View', {
    extend: 'Ext.Container',
    
    config: {
        title: 'Information',
        
        items: [
            {
                xtype: 'component',
                itemId: 'content',
                tpl: [
                    '<div>{First Name} {LastName}</div>',
                    '<div>{Email}</div>'
                ].join('')
            }
        ],
        
        record: null
    },
    
    updateRecord: function (newRecord) {
        if (newRecord) {
            this.down('#content').setData(newRecord.data);
        }
    }
});
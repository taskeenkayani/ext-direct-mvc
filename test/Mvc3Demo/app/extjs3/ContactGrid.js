Ext.ux.ContactGrid = Ext.extend(Ext.grid.GridPanel, {
    title: 'Contacts',
    pageSize: 10,
    viewConfig: {
        autoFill: true
    },
    stripeRows: true,
    
    initComponent: function() {
        var ds = new Ext.data.DirectStore({
            directFn: Contact.List,
            paramsAsHash: false,
            paramOrder: 'start|limit',
            root: 'data',
            idProperty: 'ID',
            totalProperty: 'total',
            fields: [
                {name: 'ID', type: 'int'},
                {name: 'FirstName', type: 'string'},
                {name: 'LastName', type: 'string'},
                {name: 'BirthDate', type: 'date', dateFormat: 'c'},
                {name: 'Employed', type: 'boolean'}
            ]
        });
        
        var pager = new Ext.PagingToolbar({
            store: ds,
            displayInfo: true,
            pageSize: this.pageSize
        });
        
        var config = {
            store: ds,
            bbar: pager,
            columns: [
                {header: 'First Name', dataIndex: 'FirstName'},
                {header: 'LastName', dataIndex: 'LastName'},
                {header: 'Birth Date', dataIndex: 'BirthDate', xtype: 'datecolumn', format: 'm/d/Y'},
                {header: 'Employed', dataIndex: 'Employed', xtype: 'booleancolumn', trueText: 'Yes', falseText: 'No', align: 'center'}
            ]
        };
        
        Ext.apply(this, Ext.apply(this.initialConfig, config));
        
        Ext.ux.ContactGrid.superclass.initComponent.apply(this, arguments);
    },
    
    afterRender: function() {
        this.getStore().load({
            params: {
                start: 0,
                limit: this.pageSize
            }
        });
    
        Ext.ux.ContactGrid.superclass.afterRender.apply(this, arguments);
    }
});

Ext.reg('contactgrid', Ext.ux.ContactGrid);
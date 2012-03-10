Ext.define('Demo.view.Menu', {
    extend: 'Ext.dataview.List',
    xtype: 'demomenu',

    config: {
        title: 'Menu',
        store: {
            fields: ['text', 'class'],
            data: [
                ['Basic', 'Demo.view.Basic'],
                ['List', 'Demo.view.List'],
                ['Form', 'Demo.view.Form']
            ]
        }
    }
});
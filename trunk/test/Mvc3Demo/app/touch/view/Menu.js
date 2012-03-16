Ext.define('Demo.view.Menu', {
    extend: 'Ext.dataview.List',
    xtype: 'demomenu',

    config: {
        title: 'Menu',
        store: {
            fields: ['text', 'class'],
            data: [
                ['List', 'Demo.view.List'],
                ['Form', 'Demo.view.Form']
            ]
        }
    }
});
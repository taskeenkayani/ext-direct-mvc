Ext.Loader.setConfig({
    enabled: true,
    paths: { 'Demo': '/app/extjs4' }
});

Ext.direct.Manager.addProvider(Ext.app.REMOTING_API);

Ext.require([
    'Demo.model.Contact',
    'Demo.store.Contacts',
    'Demo.view.Grid'
]);

Ext.application({
    name: 'Demo',
    
    models: ['Contact'],
    stores: ['Contacts'],

    launch: function () {
        Ext.create('Demo.view.Grid', {
            renderTo: 'content',
            width: 500,
            height: 300
        });
    }
});
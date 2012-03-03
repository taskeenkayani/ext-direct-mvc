Ext.Loader.setConfig({
    enabled: true,
    paths: { 'Test': '/app/touch' }
});

Ext.direct.Manager.addProvider(Ext.REMOTING_API);

Ext.application({
    name: 'Test',

    models: ['Contact'],
    stores: ['Contacts'],
    views: ['Main'],
    controllers: ['Main'],

    launch: function () {
        Ext.Viewport.add({
            xclass: 'Test.view.Main'
        });
    }
});
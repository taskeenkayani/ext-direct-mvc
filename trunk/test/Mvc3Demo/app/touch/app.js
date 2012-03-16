Ext.Loader.setConfig({
    enabled: true,
    paths: { 'Demo': '/app/touch' }
});

Ext.direct.Manager.addProvider(Ext.app.REMOTING_API);

Ext.application({
    name: 'Demo',

    models: ['Contact'],
    stores: ['Contacts'],
    views: ['Main'],
    controllers: ['Main'],

    launch: function () {
        Ext.Viewport.add({
            xclass: 'Demo.view.Main'
        });
    }
});
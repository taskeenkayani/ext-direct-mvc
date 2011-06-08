Ext.Loader.setConfig({enabled: true});
Ext.Loader.setPath('Demo', './app');
Ext.require('Demo.*');

Ext.application({
    name: 'Demo',

    launch: function() {
        Ext.direct.Manager.addProvider(Ext.app.REMOTING_API);

        Ext.create('Demo.SimplePanel', {
            renderTo: 'main'
        });

        Ext.direct.Manager.on('exception', function(e) {
            console.log(e);
        });
    }
});
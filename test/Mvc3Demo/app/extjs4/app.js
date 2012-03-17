Ext.Loader.setConfig({
    enabled: true,
    paths: { 'Demo': '/app/extjs4' }
});

Ext.direct.Manager.addProvider(Ext.app.REMOTING_API);

Ext.require([
    'Demo.model.Contact',
    'Demo.store.Contacts',
    'Demo.store.Tree',
    'Demo.view.Grid',
    'Demo.view.Form',
    'Demo.view.Tree',
    'Demo.view.FileForm'
]);

Ext.application({
    name: 'Demo',
    
    models: ['Contact'],
    stores: ['Contacts', 'Tree'],

    launch: function () {
        // BASIC
        Ext.get('basicBtn').on('click', function() {
            var contact = {
                FirstName: 'John',
                LastName: 'Smith',
                BirthDate: new Date('1975-9-14'),
                Employed: true
            };

            Basic.Echo("this is a basic demo", new Date(), contact, function(data) {
                var html = [
                    '<b>Echoed data</b>',
                    'String: ' + data.text,
                    'Date: ' + Ext.Date.format(Ext.Date.parse(data.date, 'c'), 'l, F d, Y g:i:s A'),
                    'Contact: ' + Ext.encode(data.contact)
                ].join('<br/>');
            
                Ext.get('echoedData').update(html);
            });
        });
        
        // NAMED ARGUMENTS
        Ext.get('namedArgsBtn').on('click', function() {
            var args = {
                contact: {
                    FirstName: 'John',
                    LastName: 'Smith',
                    BirthDate: new Date('1975-9-14'),
                    Employed: true
                },
                date: new Date(),
                text: 'this is a named arguments demo'
            };

            Basic.EchoNamedArgs(args, function(data) {
                var html = [
                    '<b>Echoed data</b>',
                    'String: ' + data.text,
                    'Date: ' + Ext.Date.format(Ext.Date.parse(data.date, 'c'), 'l, F d, Y g:i:s A'),
                    'Contact: ' + Ext.encode(data.contact)
                ].join('<br/>');
            
                Ext.get('echoedData2').update(html);
            });
        });

        // SERVER-SIDE EXCEPTION
        // BasicController.TestException method throws an exception.
        Ext.get('exceptionBtn').on('click', Basic.TestException);
    
        // exception event listener handles ALL server side exceptions and should only be set once in your code.
        Ext.direct.Manager.on('exception', function(error) {
            // error.where is present in Debug mode or if Ext.Direct.Mvc is configured with debug="true" in web.config.
            // error object can also contain any addition information that can help you with debugging. Check out BasicController.TestException.
            if (Ext.isDefined(error.where)) {
                // Detailed error message for developer
                console.error(Ext.util.Format.format('{0}\n{1}', error.message, error.where));
                Ext.Msg.show({
                    title: 'Error occured',
                    msg: Ext.util.Format.format('Exception was thrown from {0}.{1}.<br/>Check the console for details.', error.action, error.method),
                    icon: Ext.MessageBox.ERROR,
                    buttons: Ext.Msg.OK
                });
            } else {
                // User friendly message for end user
                Ext.Msg.show({
                    title: 'Error occured',
                    msg: 'Unable to process request. Please try again later.',
                    icon: Ext.MessageBox.ERROR,
                    buttons: Ext.Msg.OK
                });
            }
        });

        // GRID
        Ext.create('Demo.view.Grid', {
            width: 400,
            height: 300,
            renderTo: 'gridCt'
        });

        // FORM
        Ext.create('Demo.view.Form', {
            width: 400,
            height: 200,
            renderTo: 'formCt'
        });
        
        // TREE
        Ext.create('Demo.view.Tree', {
            width: 400,
            height: 300,
            renderTo: 'treeCt'
        });
        
        // FILE UPLOAD
        Ext.create('Demo.view.FileForm', {
            width: 400,
            height: 200,
            renderTo: 'fileFormCt'
        });
    }
});
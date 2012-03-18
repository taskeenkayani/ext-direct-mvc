Ext.onReady(function () {
    Ext.BLANK_IMAGE_URL = 'http://cdn.sencha.io/ext-3.4.0/resources/images/default/s.gif';
    Ext.Direct.addProvider(Ext.app.REMOTING_API);
    Ext.QuickTips.init();

    // BASIC
    Ext.get('basicBtn').on('click', function () {
        var contact = {
            FirstName: 'John',
            LastName: 'Smith',
            BirthDate: new Date(1970, 6, 15),
            Employed: true
        };

        Basic.Echo("lorem ipsum dolor sit amet", new Date(), contact, function (result, event) {
            var html;
            if (event.status == true) {
                html = [
                    '<b>Echoed data</b>',
                    'String: ' + result.text,
                    'Date: ' + Date.parseDate(result.date, 'c').format('l, F d, Y g:i:s A'),
                    'Contact: ' + Ext.encode(result.contact)
                ].join('<br/>');
                Ext.get('basicEchoedData').update(html);
            }
        });
    });

    // SERVER-SIDE EXCEPTION
    // BasicController.TestException method throws an exception.
    Ext.get('exceptionBtn').on('click', Basic.TestException);

    // exception event listener handles ALL server side exceptions and should only be set once in your code.
    Ext.Direct.on('exception', function (error) {
        // error.where is present in Debug mode or if Ext.Direct.Mvc is configured with debug="true" in web.config.
        // error object can also contain any addition information that can help you with debugging. Check out BasicController.TestException.
        if (Ext.isDefined(error.where)) {
            // Detailed error message for developer
            console.error(String.format('{0}\n{1}', error.message, error.where));
            Ext.Msg.show({
                title: 'Error occured',
                msg: String.format('Exception was thrown from {0}.{1}.<br/>Check the console for details.', error.action, error.method),
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
    var grid = new Ext.ux.ContactGrid({
        width: 400,
        height: 300,
        renderTo: 'gridCt'
    });

    // FORM
    var form = new Ext.ux.ContactForm({
        width: 400,
        height: 200,
        renderTo: 'formCt'
    });

    // TREE
    var tree = new Ext.ux.BasicTree({
        width: 400,
        height: 300,
        renderTo: 'treeCt'
    });

    // FILE UPLOAD
    var fileForm = new Ext.ux.FileForm({
        width: 400,
        height: 200,
        renderTo: 'fileFormCt'
    });
});
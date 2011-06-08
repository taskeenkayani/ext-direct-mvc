Ext.define('Demo.SimplePanel', {
    extend: 'Ext.panel.Panel',
    alias: 'simplepanel',

    title: 'Simple Panel',
    width: 400,
    height: 300,
    autoScroll: true,
    frame: true,
    bodyCls: 'simple-body',
    buttonAlign: 'center',
    
    initComponent: function() {
        this.buttons = [{
            text: 'Echo Text',
            handler: this.onEchoText,
            scope: this
        }, {
            text: 'Add Numbers',
            handler: this.onAddNumbers,
            scope: this
        }, {
            text: 'Echo Person',
            handler: this.onEchoPerson,
            scope: this
        }, {
            text: 'Exception',
            handler: this.onFakeException,
            scope: this
        }];

        this.callParent();
    },

    onEchoText: function() {
        var text = prompt('Enter some text to echo', 'Lorem ipsum dolor sit amet');
        text = Ext.String.trim(text);
        if (text.length > 0) {
            Demo.EchoText(text, function(result, response) {
                this.updateBody(result);
            }, this);
        }
    },

    onAddNumbers: function() {
        var a = prompt('Enter first number');
        if (Ext.isNumeric(a)) {
            var b = prompt('Enter second number');
            if (Ext.isNumeric(b)) {
                Demo.AddNumbers(a, b, function(result, response) {
                    this.updateBody(Ext.String.format('{0} + {1} = {2}', a, b, result));
                }, this);
            }
        }
    },

    onEchoPerson: function() {
        var person = {
            Name: 'John Smith',
            Email: 'john.smith@example.com',
            Gender: 'Male',
            Birthday: new Date('12/31/1969'),
            Salary: 55000
        };
        Demo.EchoPerson(person, function(result, response) {
            var tpl = new Ext.Template(
                '<span class="label">Name:</span> {Name}<br/>',
                '<span class="label">Email:</span> {Email}<br/>',
                '<span class="label">Gender:</span> {Gender}<br/>',
                '<span class="label">Birthday:</span> {Birthday:date("m/d/Y")}<br/>',
                '<span class="label">Salary:</span> {Salary:usMoney}'
            );
            this.updateBody(tpl.apply(result));
        }, this);
    },

    onFakeException: function() {
        Demo.FakeException();
    },

    updateBody: function(msg) {
        var oldHtml = this.body.dom.innerHTML;
        this.body.dom.innerHTML = '<div class="result">' + msg + '</div>';
        
        if (oldHtml.length > 0) {
            this.body.dom.innerHlTML += oldHtml;
        }
    }
});
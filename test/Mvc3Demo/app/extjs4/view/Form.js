Ext.define('Demo.view.Form', {
    extend: 'Ext.form.Panel',
    title: 'Contact',
    bodyPadding: 10,
    defaults: {
        anchor: '100%',
        labelWidth: 80
    },
    items: [
        { xtype: 'textfield', name: 'FirstName', fieldLabel: 'First Name', allowBlank: false },
        { xtype: 'textfield', name: 'LastName', fieldLabel: 'Last Name', allowBlank: false },
        { xtype: 'datefield', name: 'BirthDate', fieldLabel: 'Birth Date', format: 'm/d/Y', altFormats: 'c', allowBlank: false },
        { xtype: 'checkboxfield', name: 'Employed', fieldLabel: 'Employed', inputValue: 'true' }
    ],
    bbar: [
        { text: 'Load Contact', itemId: 'loadButton' },
        '->',
        { text: 'Save Contact', itemId: 'saveButton', disabled: true }
    ],

    initComponent: function () {
        var config, loadButton, saveButton;

        config = {
            api: {
                load: Form.LoadContact,
                submit: Form.SaveContact
            },
            paramOrder: 'id'
        };
        
        Ext.apply(this, Ext.apply(this.initialConfig, config));

        this.callParent(arguments);

        loadButton = this.down('#loadButton');
        saveButton = this.down('#saveButton');

        loadButton.on('click', function () {
            this.getForm().load({
                params: {
                    id: 1
                },
                success: function () {
                    saveButton.enable();
                }
            });
        }, this);

        saveButton.on('click', function () {
            this.getForm().submit({
                params: {
                    id: 1
                },
                success: function () {
                    alert('Contact saved!');
                }
            });
        }, this);
    }
});
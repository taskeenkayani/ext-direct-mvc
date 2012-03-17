Ext.ux.ContactForm = Ext.extend(Ext.form.FormPanel, {
    title: 'Contact',
    padding: 10,
    labelWidth: 80,
    defaults: {
        anchor: '100%'
    },
    
    initComponent: function () {
        var config = {
            api: {
                load: Form.LoadContact,
                submit: Form.SaveContact
            },
            paramOrder: ['id'],
            items: [
                { xtype: 'textfield', name: 'FirstName', fieldLabel: 'First Name', allowBlank: false },
                { xtype: 'textfield', name: 'LastName', fieldLabel: 'Last Name', allowBlank: false },
                { xtype: 'datefield', name: 'BirthDate', fieldLabel: 'Birth Date', format: 'm/d/Y', altFormats: 'c', allowBlank: false },
                { xtype: 'checkbox', name: 'Employed', fieldLabel: 'Employed', inputValue: 'true' }
            ],
            bbar: [
                { text: 'Load Contact', ref: '../loadButton', handler: this.onLoadClick, scope: this },
                '->',
                { text: 'Save Contact', ref: '../saveButton', disabled: true, handler: this.onSaveClick, scope: this }
            ]
        };
        
        Ext.apply(this, Ext.apply(this.initialConfig, config));
        
        Ext.ux.ContactForm.superclass.initComponent.call(this);
    },
    
    onLoadClick: function () {
        this.getForm().load({
            params: {
                id: 1
            },
            success: function () {
                this.saveButton.enable();
            },
            scope: this
        });
    },
    
    onSaveClick: function () {
        this.getForm().submit({
            params: {
                id: 1
            },
            success: function () {
                alert('Contact saved!');
            }
        });
    }
});
Ext.onReady(function(){
	Ext.BLANK_IMAGE_URL = 'http://extjs.cachefly.net/ext-3.4.0/resources/images/default/s.gif'
	
	var CurrencyRefrecord = Ext.data.Record.create([{
        name: 'name',
        type: 'string'
    }, {
        name: 'nominal',
        type: 'integer'
    }, {
        name: 'charcode',
        type: 'string',
    },{
        name: 'code',
        type: 'string'
    },{
        name: 'numcode',
        type: 'integer'
    }]);

	var DateFilter = new Ext.form.DateField({
		id: 'RateDateFilter',
		format: 'd.m.Y',
		value : new Date(),
		allowBlank: false,
		xtype: 'datefield',
		fieldLabel: 'Дата',
		id: 'datefilter',
		format : "d.m.Y",
		showToday: true,
		listeners:{ 
				
			select: { 
				fn:function(datefield, date){     
					jstoreRate.load();
					}
				}
			},
		width: 100,
				
					
				
      });
	
	
	var editorRefGrid = new Ext.ux.grid.RowEditor({
		listeners: {
			'afteredit': function(editor,chgbj,record,rownumber){
								jstore.save();
							}
		},
        saveText: 'Сохранить',
		cancelText: 'Отменить',
    });
	
	var writerRefStore = new Ext.data.JsonWriter({
		encode: false,
		listful: true,
		writeAllFields: true
		});
		
	var	proxy = new Ext.data.HttpProxy({
		api: {
		read: {url: '/currencyref/read', method: 'POST'},
		create: {url: '/currencyref/create', method: 'POST'},
		destroy: {url: '/currencyref/delete', method: 'POST'},
		update: {url: '/currencyref/update', method: 'POST'}
		}
	});	

	var CreateNewRateStore = new Ext.data.JsonStore({
		autoSave: false,
		writer: writerRateStore,
		idProperty: 'id',
		baseParams: {start: 0, limit: 100},
		root: 'data',
		proxy : proxy,
		totalProperty: 'results',
		reader: {
		type: 'json',
		root: 'data',
		totalProperty: 'results'
		},
		layoutConfig: 'form',
		fields: [
			{name: 'id', type: 'integer'}, 'charcode', {name: 'nominal', type: 'integer'},'code','name'
		]});

																		
	var jstore = new Ext.data.JsonStore({
		autoSave: false,
		autoLoad: false,
		baseParams: {start: 0, limit: 20},
		writer: writerRefStore,
		idProperty: 'id',
		root: 'data',
		proxy : proxy,
		totalProperty: 'results',
		reader: {
		type: 'json',
		root: 'data',
		totalProperty: 'results'
		},
		layoutConfig: 'fit',
		fields: [
			{name: 'id', type: 'integer'},
			'code', {name :'nominal' , type: 'float'}, 'name', {name :'numcode' , type: 'integer'},'charcode'
		],
	});
	
	var mybbar = new Ext.PagingToolbar({
		store: jstore,
		pageSize:20,
		displayInfo:true
		});
	
	var grid = new Ext.grid.GridPanel({
		id: 'panelgrid',
		store: jstore,
		columns: [
			{header: 'Название', width: 250, sortable: true, dataIndex: 'name', 
			editor: {
                xtype: 'textfield',
                allowBlank: false,
                
            }},
			{header: 'Номинал', xtype: 'numbercolumn', format: '0,000', width: 70, sortable: true, dataIndex: 'nominal',editor: {
                xtype: 'numberfield',
                allowBlank: false,
                
            }},
			{header: 'Код ISO(буквенный)', width: 120, sortable: true, dataIndex: 'charcode',editor: {
                xtype: 'textfield',
                allowBlank: false,
                
            }},
			{header: 'Код валюты', width: 80, sortable: true, dataIndex: 'code',editor: {
                xtype: 'textfield',
                allowBlank: false,
                
            }},
			{header: 'Код ISO(числовой)', format: '0', xtype: 'numbercolumn', width: 120, sortable: true, dataIndex: 'numcode',editor: {
                xtype: 'numberfield',
                allowBlank: false,
                
            }}
		],
		stripeRows: true,
		plugins: [editorRefGrid],
		tbar: { layout: 'hbox',
				items:[
				{
						width: 70,
                        text:'Добавить',
                        handler: function(){
							var r = new CurrencyRefrecord({
								name: '',
								nominal: 1,
								charcode: '',
								code: '',
								numcode: 0
							});
							editorRefGrid.stopEditing();
							jstore.insert(0, r);
							grid.getView().refresh();
							grid.getSelectionModel().selectRow(0);
							editorRefGrid.startEditing(0);
						}
                },
				{
							width: 70,
							id: 'removeBtn',
							text: 'Удалить',
							disabled: true,
							handler: function(){
								editorRefGrid.stopEditing();
								var s = grid.getSelectionModel().getSelections();
								for(var i = 0, r; r = s[i]; i++){
									jstore.remove(r);
								}
								jstore.save();
							}
				},
				{
							xtype: 'label',
							flex: 1,
				},
				{
							text:'Очистить записи и загрузить из базы ЦБ',
							handler:function(datefield, date){     
								Ext.Ajax.request({
									url: '/cbr/create',
									method: 'POST',
									success: function(response,request){
												jstore.load();
									},
									failure: function(response,request){
												Ext.Msg.alert('Ошибка',response.statusText);
									},
									params: { action: 'refreshRefs' }
								});
							}
                }]},
		bbar : mybbar,
		height: 500,
		layout: 'form',
		title:'Справочник валют'
	});
	
	var CurrencyRaterecord = Ext.data.Record.create([{
        name: 'name',
        type: 'string'
    }, {
        name: 'charcode',
        type: 'string'
    },{
        name: 'code',
        type: 'string'
    },{
        name: 'rate',
        type: 'float',
    }, {
        name: 'date',
        type: 'date',
    },{
        name: 'nominal',
        type: 'integer',
    }]);
	
	

		
	
	var editorRateGrid = new Ext.ux.grid.RowEditor({
		listeners: {
			'afteredit': function(editor,chgbj,record,rownumber){
								jstoreRate.save();
							}
		},
        saveText: 'Сохранить',
		cancelText: 'Отменить',
    });
	
	var writerRateStore = new Ext.data.JsonWriter({
		encode: false,
		listful: true,
		writeAllFields: true
		});
		
	var	proxyRate = new Ext.data.HttpProxy({
		api: {
		read: {url: '/currencyrates/read', method: 'POST'},
		create: {url: '/currencyrates/create', method: 'POST'},
		destroy: {url: '/currencyrates/delete', method: 'POST'},
		update: {url: '/currencyrates/update', method: 'POST'}
		}
	});	
	
	var jstoreRate = new Ext.data.JsonStore({
		autoSave: false,
		baseParams: {start: 0, limit: 20, date: DateFilter.getValue()},
		autoLoad: true,
		writer: writerRateStore,
		listeners:{ 
				
						beforeload: { 
							fn:function(store,object){     
								store.setBaseParam('date',DateFilter.getValue());
								}
							}
						},
		idProperty: 'id',
		root: 'data',
		proxy : proxyRate,
		totalProperty: 'results',
		reader: {
		type: 'json',
		root: 'data',
		totalProperty: 'results'
		},
		layoutConfig: 'fit',
		fields: [
			{name: 'id', type: 'integer'}, 'charcode',
			'name', {name :'nominal' , type: 'float'}, {name :'date' , type: 'date'},{name :'rate' , type: 'float'}
		],
		sortInfo: { field: 'date', direction: "DESC" }
	});
	

	
	
	var mybbarRate = new Ext.PagingToolbar({
		store: jstoreRate,
		pageSize:20,
		displayInfo:true
		});
	


	var gridRate = new Ext.grid.GridPanel(
	{
		id: 'panelgridrate',
		store: jstoreRate,
		columns: [
			{header: 'Дата', width: 80, sortable: true, renderer: Ext.util.Format.dateRenderer("d.m.Y"), dataIndex: 'date',
					editor: {xtype: 'datefield',allowBlank: false}
				},
			{header: 'Наименование', width: 250, sortable: true, dataIndex: 'name'},
			{header: 'Код ISO(буквенный)', width: 120, sortable: true, dataIndex: 'charcode' },
			{header: 'Номинал', xtype: 'numbercolumn', format: '0,000', width: 70, sortable: true, dataIndex: 'nominal'},
			{header: 'Курс', width: 70, format: '0,0.0000', sortable: true, dataIndex: 'rate',
				editor: {xtype: 'numberfield',allowBlank: false, decimalPrecision : 4}
				}
		],
		stripeRows: true,
		plugins: [editorRateGrid],
		tbar: {	layout: 'hbox',
				items:[
				{
					width: 70,
                    text:'Добавить',
                    handler: function(){
						CreateNewRateStore.reload();
					}
                },
				{
					width: 70,
					id: 'removeRateBtn',
					text: 'Удалить',
					disabled: true,
					handler: function(){
						editorRateGrid.stopEditing();
						var s = gridRate.getSelectionModel().getSelections();
						for(var i = 0, r; r = s[i]; i++){
							jstoreRate.remove(r);
							}
						jstoreRate.save();
					}
				},{
					flex: 1,
					xtype: 'label',
					},{
					width: 110,
					xtype: 'label',
					text: 'Отобразить на дату:',
					},
				DateFilter,
				]},
		bbar : mybbarRate,
		height: 500,
		title:'Курсы валют к рюблю'
	});
	
	
	
	
	var tabpanel = new Ext.TabPanel({
		activeTab: 0,
		id: 'tabpanel',
		defaults:{autoScroll: true},
		items: [
		{
			title: 'Курсы валют',
			items: gridRate

		},
		{
			title: 'Справочник валют',
			items: grid,
			listeners: {
					activate : function activatedPanelHandler(panel){
						jstore.load();
						panel.removeListener('activate',activatedPanelHandler);
					}
			}
		}]
	});
	

	CreateNewRateStore.on('load',function(s,rs) {
		new Ext.Window({
			title : 'Добавление новой котировки',
			width : 350,
			closable : true,
			resizable : false,
			height: 200,
			closeAction: 'close',
			tbar: {
				items:[{
					disabled: true,
					text:'Добавить',
					id: 'btnAddRate',
					handler: function(){
							var r = new CurrencyRaterecord({
								name: Ext.getCmp('RatesNamesCmb').getValue(),
								nominal: Ext.getCmp('nominal').getValue(),
								charcode: Ext.getCmp('RatesCmb').getValue(),
								code: '',
								rate: Ext.getCmp('currate').getValue(),
								date: Ext.getCmp('newdt').getValue()
							});
							jstoreRate.insert(0, r);
							jstoreRate.save();
							jstoreRate.load();
							Ext.getCmp('CreateRateWindow').close();
						}
					},
					{
						text:'Отменить',
						handler:function(){
							Ext.getCmp('CreateRateWindow').close();  
						}
					}]},
			items :[
															
				{
					xtype: 'combo',
					id: 'RatesNamesCmb',
					fieldLabel: 'Наименование',
					store: CreateNewRateStore,
					displayField: 'name',
					valueField: 'name',
					selectOnFocus: true,
					mode: 'local',
					typeAhead: true,
					editable: false,
					triggerAction: 'all',
					value : CreateNewRateStore.getAt(0).get('name'),
					listeners:{ 
						select: { 
							fn:function(combo, record,index){                                         
								Ext.getCmp('newdt').setValue('');;
								Ext.getCmp('nominal').setValue(record.get('nominal'));
								Ext.getCmp('RatesCmb').setValue(record.get('charcode'));
							}  
						}
					}		
				},{
					xtype: 'combo',
					id: 'RatesCmb',
					fieldLabel: 'Код',
					store: CreateNewRateStore,
					displayField: 'charcode',
					valueField: 'charcode',
					selectOnFocus: true,
					mode: 'local',
					typeAhead: true,
					editable: false,
					triggerAction: 'all',
					value : CreateNewRateStore.getAt(0).get('charcode'),
					listeners:{ 
						select: { 
							fn:function(combo, record,index){                                         
								var field = Ext.getCmp('nominal');
								Ext.getCmp('newdt').setValue('');;
								field.setValue(record.get('nominal'));
								Ext.getCmp('RatesNamesCmb').setValue(record.get('name'));
							}  
						}
					}		
				},{		
					xtype: 'datefield',
					fieldLabel: 'Дата',
					name: 'newdt',
					id: 'newdt',
					format : "d.m.Y",
					showToday: true,
					listeners:{ 
						select: { 
							fn:function(datefield, date){     
								Ext.Ajax.request({
									url: '/cbr/read',
									method: 'POST',
									success: function(response,request){
												var json = Ext.util.JSON.decode(response.responseText);
												Ext.getCmp('currate').setValue(json.rate);
												Ext.getCmp('btnAddRate').setDisabled(false);
									},
									failure: function(response,request){
												Ext.Msg.alert('Ошибка',response.statusText);
									},
									params: { action: 'getRate', code: Ext.getCmp('RatesCmb').getValue(),date: date }
								});
							}
						}
					},
				},{		
					xtype: 'numberfield',
					fieldLabel: 'Номинал',
					name: 'nominal',
					id: 'nominal',
					value: CreateNewRateStore.getAt(0).get('nominal'),
				},{		
					xtype: 'numberfield',
					fieldLabel: 'Курс',
					format : '0,0.0000',
					decimalPrecision: 4,
					name: 'currate',
					id: 'currate',
				}],
			ownerCt : this,
			modal : true,
			layout : 'form',
			id: 'CreateRateWindow',
			}).show(); 
	});
	
	
	grid.getSelectionModel().on('selectionchange', function(sm){
        Ext.getCmp('removeBtn').setDisabled(sm.getCount() < 1);
    });
	
	gridRate.getSelectionModel().on('selectionchange', function(sm){
        Ext.getCmp('removeRateBtn').setDisabled(sm.getCount() < 1);
    });
	

	new Ext.Window({
		width:800, height: 550,
		closable: false,
		resizable: false,
		layout: 'form',
		items: [{
			items: tabpanel
		}]
	}).show();
	
	
});

Feature: UC003
@UC003
    Scenario Outline: Realizar a busca de um ativo de mercado e fazer a compra
    Given o acesso ao sistema
	And seleciono o ativo <Ativo> 
	And realizo uma ordem de <Ordem>	
	Then O sistema exibe a mensagem <Mensagem>
	
	Examples: 
      | Ativo  | Ordem   | Mensagem                |
      | PETR4| VENDER |Ordem enviada com sucesso. |
      #| PETR4 | COMPRAR|Ordem enviada com sucesso. |
      #| VALE3 | VENDER |Ordem enviada com sucesso. |
      #| JBSS3 | VENDER |Ordem enviada com sucesso. |
      #| FIBR3 | COMPRAR|Ordem enviada com sucesso. |
     

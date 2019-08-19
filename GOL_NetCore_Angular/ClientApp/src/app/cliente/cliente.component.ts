import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';
import { ClienteService } from '../Services/cliente.service';
import { ICliente } from '../Models/cliente.interface';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html'
})

export class ClienteComponent implements OnInit {

  clientes: ICliente[] = [];
  cliente: ICliente = <ICliente>{};
  public form: FormGroup;

  constructor(private clienteService: ClienteService, private fb: FormBuilder) {
    // Set Validacao Form //
    this.form = fb.group({
      'id': ["0"],
      'modelo': ["", Validators.required],
      'qtdepassageiro': ["", Validators.required]
    });
  }

  // Listar all //
  getClientes() {
    this.clienteService.getClientes().subscribe(
      data => { this.clientes = data },
      error => console.error(error)
    );
  }

  // Listar Id //
  getClienteID(id) {
    this.cliente.id = id;
    this.clienteService.getClientesID(this.cliente).subscribe(
      data => {
        this.form.controls["id"].setValue(data.id);
        this.form.controls["modelo"].setValue(data.modelo);
        this.form.controls["qtdepassageiro"].setValue(data.qtdepassageiro);
      },
      error => console.error(error)
    );
  }

  // Add e ou Update //
  onSubmit() {
    this.cliente.id = this.form.controls["id"].value;
    this.cliente.modelo = this.form.controls["modelo"].value;
    this.cliente.qtdepassageiro = this.form.controls["qtdepassageiro"].value;

    this.clienteService.addClientes(this.cliente).subscribe(
      response => {
        this.getClientes();
        this.form.reset();
        this.form.controls["id"].setValue("0");
      },
      error => console.error(error)
    );
  };

  // Inicializa componente //
  ngOnInit() {
    this.getClientes();
  }
}

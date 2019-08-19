import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { ICliente } from '../Models/cliente.interface';

@Injectable()

export class ClienteService {

  constructor(private http: HttpClient) { }

  // Listar //
  getClientes() {
    return this.http.get('/api/Airplane').map(data => <ICliente[]> data);
  }

  // Listar Id //
  getClientesID(cliente: ICliente) {
    return this.http.get('/api/Airplane/' + cliente.id).map(data => <ICliente>data);
  }

  // Add e ou Update //
  addClientes(cliente: ICliente) {
    var model = new HttpParams().set('ID', cliente.id.toString())
      .set('MODELO', cliente.modelo.toString())
      .set('QTDEPASSAGEIRO', cliente.qtdepassageiro.toString())
      .set('DATACRIACAO', null);

    return this.http.post('/api/Airplane', model);
  }

}

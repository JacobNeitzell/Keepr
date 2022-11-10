import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get("api/keeps")
    AppState.keep = res.data.map(k => new Keep(k))
  }


  async setActiveKeep(keep) {
    AppState.activeKeep = keep;
    const res = await api.get(`api/keeps/${keep.id}`)
    AppState.keep.views++
  }


  async getKeepById(keepId) {
    const res = await api.get(`api/keeps/${keepId}`);
    AppState.activeKeep = new Keep(res.data);
  }

  async GetKeepsByProfie(id) {
    const res = await api.get('api/profile/' + id)
    AppState.ProfileKeep = new Keep(res.data)
    return res.data
  }

}
export const keepsService = new KeepsService()
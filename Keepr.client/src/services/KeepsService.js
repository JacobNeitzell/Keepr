import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get("api/keeps")
    AppState.keep = res.data.map(k => new Keep(k))
  }
  async deleteKeep(id) {
    const res = await api.delete('api/keeps/' + id)
    AppState.activeKeep = AppState.keep.filter((k) => k.Id != id)
  }

  async setActiveKeep(keep) {
    const res = await api.get(`api/keeps/${keep.id}`)
    let id = keep.vaultKeepId
    AppState.activeKeep = new Keep(res.data);
    if (id) {
      AppState.activeKeep.vaultKeepId = keep.vaultKeepId
    }
    logger.log(AppState.activeKeep)
  }


  // async getKeepById(keepId) {
  //   const res = await api.get(`api/keeps/${keepId}`);
  //   AppState.activeKeep = new Keep(res.data);
  // }

  async GetKeepsByProfile(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.profileKeep = res.data.map((p) => new Keep(p))
  }


  async CreateKeep(data) {
    const res = await api.post("api/keeps", data)
    AppState.keep.push(res.data)

  }







}
export const keepsService = new KeepsService()
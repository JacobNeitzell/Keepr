import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { logger } from "../utils/Logger.js"
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

  async GetKeepsByProfile(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    logger.log(res.data)
    AppState.keep.creator = AppState.ProfileKeep
    AppState.ProfileKeep = res.data
    return res.data
  }


  async CreateKeep(data) {
    const res = await api.post("api/keeps", data)
    AppState.keep.push(res.data)

  }




}
export const keepsService = new KeepsService()
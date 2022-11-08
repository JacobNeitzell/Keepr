import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { api } from "./AxiosService.js"

class KeepsService {

  async getKeeps() {
    const res = await api.get("api/keeps")
    AppState.keep = res.data.map(k => new Keep(k))
  }




}
export const keepsService = new KeepsService()
import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async AddKeeptoVault(keepData) {
    const res = await api.post("api/vaultkeeps", keepData)
    vaultkeep.keepId = res.data
    AppState.keepId.push(vaultId)
  }

  async GetVaultKeeps(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    AppState.vaultkeeps = res.data.map((v) => new Keep(v))
  }


}
export const vaultKeepsService = new VaultKeepsService()
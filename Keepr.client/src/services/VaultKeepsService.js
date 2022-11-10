import { AppState } from "../AppState.js"
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
    AppState.vault.creator = AppState.vaultkeep
    AppState.vaultkeep = res.data
    return res.data
  }


}
export const vaultKeepsService = new VaultKeepsService()
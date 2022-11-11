import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { VaultKeep } from "../models/VaultKeep.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {

  async AddKeeptoVault(keepData) {
    const res = await api.post("api/vaultkeeps", keepData)
    logger.log(res.data)
    AppState.activeKeep.kept++
    // AppState.vaultkeeps.push(new VaultKeep(res.data))
  }

  async GetVaultKeeps(vaultId) {
    const res = await api.get('api/vaults/' + vaultId + '/keeps')
    AppState.vaultkeeps = res.data.map((v) => new Keep(v))
  }

  async deleteVaultKeep(id) {
    const res = await api.delete('api/vaultkeeps/' + id)
    AppState.vaultkeeps = AppState.vaultkeeps.filter((v) => v.vaultKeepId != id)
  }


}
export const vaultKeepsService = new VaultKeepsService()
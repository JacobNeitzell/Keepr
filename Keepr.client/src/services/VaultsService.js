import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async getVault(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.activeVault = new Vault(res.data);

  }


  async GetVaultsByProfile(id) {
    const res = await api.get('api/profiles/' + id + '/vaults')
    AppState.vault.creator = AppState.profileVault
    AppState.profileVault = res.data
    return res.data
  }


  async CreateVault(data) {
    const res = await api.post("api/vaults", data)
    AppState.vault.push(res.data)
  }

}
export const vaultService = new VaultsService()
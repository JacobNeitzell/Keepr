import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async getVault(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.profileVault = new Vault(res.data);

  }


  async GetVaultsByProfile(vaultId) {
    const res = await api.get('api/profiles/' + vaultId + '/vaults')
    AppState.vault.creator = AppState.profileVault
    AppState.profileVault = res.data
    return res.data
  }

  async setActiveVault(vault) {
    AppState.activeVault = vault;
    const res = await api.get(`api/vaults/${vault.id}`)
  }

  async CreateVault(data) {
    const res = await api.post("api/vaults", data)
    AppState.vault.push(res.data)
  }

}
export const vaultService = new VaultsService()
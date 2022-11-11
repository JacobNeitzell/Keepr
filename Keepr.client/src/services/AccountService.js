import { AppState } from '../AppState'
import { Account } from "../models/Account.js"
import { Vault } from "../models/Vault.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }


  async UpdateAccount(accountData) {
    const res = await api.put('/account', accountData)
    AppState.account = new Account(res.data)
  }

  async getMyVault() {
    const res = await api.get("/account/vaults")
    console.log(res.data);
    AppState.myVaults = res.data.map((v) => new Vault(v))
    console.log(AppState.myVaults);
  }

  async getMyKeep() {
    const res = await api.get(`/profiles/${profileId}/keeps`)
    AppState.myKeep = res.data
  }


}

export const accountService = new AccountService()

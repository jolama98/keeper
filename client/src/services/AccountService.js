import { Vault } from '@/models/Vault.js'
import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async updateAccount(accountData) {
    const response = await api.put('/account', accountData)
    logger.log('UPDATED ACCOUNT 🤵', response.data)
    AppState.account = new Account(response.data)
  }


  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }


  async getAccountVaults() {

    const response = await api.get('account/vaults')
    logger.log(response.data)
    const myVaults = response.data.map(vaultPOJO => new Vault(vaultPOJO))
    AppState.accountVaults = myVaults

  }
}

export const accountService = new AccountService()

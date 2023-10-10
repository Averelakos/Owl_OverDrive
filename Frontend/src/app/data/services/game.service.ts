import { Injectable } from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams} from "@angular/common/http";
import { CreateAlternativeTitleDto, CreateGameDto, CreateGameGenreDto, CreateGameLocalizationDto, CreateGameModeDto, CreateGamePlayerPerspectiveDto, CreateGameThemeDto, CreateImageDto, CreateInvolvedCompanyDto, CreateInvolvedCompanyPlatformDto, CreateLanguageSupportDto, CreateMultiplayerModeDto, CreateReleaseDateDto, CreateWebsite } from "../types/game/create-game";
import { GameSimpleDto } from "../types/game/GameSimpleDto";
import { ServiceSearchResultData } from "../types/service-results/service-searc-result-data";
import { DataLoaderOptions } from "../types/data-loader/data-loader-options";
import { BehaviorSubject } from "rxjs";
import { GameDetailsDto } from "../types/game/game-details-dto";
import { UpdateAlternativeTitleDto, UpdateGameDto, UpdateGameGenreDto, UpdateGameLocalizationDto, UpdateGameModeDto, UpdateGamePlayerPerspectiveDto, UpdateGameThemeDto, UpdateInvolvedCompanyDto, UpdateInvolvedCompanyPlatformDto, UpdateLanguageSupportDto, UpdateMultiplayerModeDto, UpdateReleaseDateDto, UpdateWebsite } from "../types/game/update-game";
import { EWebsites } from "src/app/core/enums/enum-websites";
import { ServiceResult } from "../types/service-results/service-result";
import { CreateGameResponseDto } from "../types/game/responses/create-game-response-dto";
import { AddUserReviewDto } from "../types/game/add-user-review";
import { GameUserReviewsDto } from "../types/game/game-user-review";


@Injectable()
export class GameService{
  uri: string = 'Game'
  baseUrl = environment.apiUrl+this.uri;
  searchString: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null)
  gameReviewDetails
  constructor(private readonly formBuilder: FormBuilder, private http: HttpClient){}

  initForm(): FormGroup {
      return this.formBuilder.group({
        general: this.formBuilder.group({
          name:[null],
          description:[null],
          image:[null],
          updateGameType: [null],
          updatedGameId:[null],
          gameStatus:[null],
          cover: [null],
          gameEdition:this.formBuilder.group({
            baseGame: [null],
            editionTitle: [null]
          }),
          gameAlternativeNames:this.formBuilder.array([])
        }),
        localization: this.formBuilder.array([]),
        categorization: this.formBuilder.group({
          genre:[null],
          theme:[null],
          perspectives:[null],
          gameMode:[null],
          multiplayerModes: this.formBuilder.array([])
        }),
        releaseDates: this.formBuilder.array([]),
        websites: this.formBuilder.group({
          steam: [null],
          epicgames: [null],
          iphone: [null],
          itch: [null],
          gog:[null],
          android:[null],
          ipad: [null],
          official: [null],
          twitch: [null],
          youtube: [null],
          facebook: [null],
          twitter:[null],
          instagram:[null],
          discord: [null],
          reddit:[null]
        }),
        companies: this.formBuilder.array([]),
        storyline: [null],
        supportedLanguage: this.formBuilder.group({
          audio:[null],
          subtitle:[null],
          interface:[null]
        })
      })
  }

  populateForm(gameForm: FormGroup, response: UpdateGameDto){
    this.general(gameForm).get('name')?.patchValue(response.name)
    this.general(gameForm)?.get('description')?.patchValue(response.description)
    this.general(gameForm)?.get('gameStatus')?.patchValue(response.gameStatus)
    this.general(gameForm).get('updateGameType')?.patchValue(response.gameType)
    this.general(gameForm).get('updatedGameId')?.patchValue(response.parentGameId)
    this.general(gameForm).get('cover')?.patchValue(response.cover)
    gameForm.get('storyline')?.patchValue(response.story)

    // Alternative titles
    if(response.alternativeNames != null &&  response.alternativeNames.length > 0) {
      let tempArray = this.general(gameForm).get('gameAlternativeNames') as FormArray
      response.alternativeNames.forEach((x) => {
        let temp = this.formBuilder.group({
          alternativeName: x.alternativeName,
          alternativeTitleType: x.type
        })
        tempArray.push(temp)
      })
    }

    // Localization
    if(response.gameLocalizations != null && response.gameLocalizations.length > 0) {
      let tempArray = this.localization(gameForm)
      response.gameLocalizations.forEach((x) => {
        let temp = this.formBuilder.group({
          region: x.regionId,
          localizedTitle: x.localizedTitle
        })
        tempArray.push(temp)
      })
    }

    //Genre
    if (response.gameGenres != null && response.gameGenres.length > 0) {
      let tempArray: Array<number> = []
      response.gameGenres.forEach((x) => {
        let temp = x.genreId
        tempArray.push(temp)
      })
      this.categorization(gameForm).get('genre')?.patchValue(tempArray)
    }

    //Theme
    if (response.gameThemes != null && response.gameThemes.length > 0) {
      let tempArray: Array<number> = []
      response.gameThemes.forEach((x) => {
        let temp = x.themeId
        tempArray.push(temp)
      })
      this.categorization(gameForm).get('theme')?.patchValue(tempArray)
    }

    //Perspective
    if(response.playerPerspectives != null && response.playerPerspectives.length > 0) {
      let tempArray: Array<number> = []
      response.playerPerspectives.forEach((x) => {
        let temp = x.playerPerspectiveId
        tempArray.push(temp)
      })
      this.categorization(gameForm).get('perspectives')?.patchValue(tempArray)
    }

    //Game mode
    if(response.gameModes != null && response.gameModes.length > 0) {
      let tempArray: Array<number> = []
      response.gameModes.forEach((x) => {
        let temp = x.gameModeId
        tempArray.push(temp)
      })
      this.categorization(gameForm).get('gameMode')?.patchValue(tempArray)
    }

    //Multiplaye mode
    if(response.multiplayerModes != null && response.multiplayerModes.length > 0) {
      let tempArray = this.categorization(gameForm).get('multiplayerModes') as FormArray
      response.multiplayerModes.forEach((x) => {
        let temp = this.formBuilder.group({
          platform:x.platformId,
          onlineCoOpMax:x.onlineCoopMax,
          offlineCoOpMax:x.offlineCoopMax,
          onlineMax:x.onlineMax,
          offlineMax:x.offlineMax,
          onlineCoOp:x.onlineCoop,
          offlineCoOp:x.offlineCoop,
          lanCoOp:x.lanCoop,
          coOpCampaign:x.campaignCoop,
          onlineSplitScreen:x.splitScreenOnline,
          offlineSpliteScreen:x.splitScreen,
          dropInOut:x.dropIn
        })
        tempArray.push(temp)
      })
    }

    //Release Dates
    if (response.releaseDates != null && response.releaseDates.length > 0) {
      response.releaseDates.forEach((entry) => {
        let arrayTempValues = this.releaseDates(gameForm).value
        let containsPlatform = arrayTempValues.find((x) => x.platform === entry.platformId)
        if(containsPlatform != null) {
          let releaseTemp = this.formBuilder.group({
            date:entry.date,
            region:entry.regionId,
            status:entry.status,
          })
          let index = arrayTempValues.map((x) => x.platform).indexOf(containsPlatform.platform)
          let test = this.releaseDates(gameForm).controls[index].get('releases') as FormArray
          test.push(releaseTemp)
        } else {
          let temp = this.formBuilder.group({
            platform:entry.platformId,
            releases: this.formBuilder.array([])
          })
          let releaseTemp = this.formBuilder.group({
            date:entry.date,
            region:entry.regionId,
            status:entry.status,
          })
          let tempArray = temp.controls.releases as FormArray
          tempArray.push(releaseTemp)
          this.releaseDates(gameForm).push(temp)
        }
      })
    }

    // Websites
    if(response.websites != null && response.websites.length > 0) {
      response.websites.forEach((entry) => {
        switch (entry.category){
          case EWebsites.android:
            this.websites(gameForm).controls['android'].patchValue(entry.url)
            break
          case EWebsites.epicgames:
            this.websites(gameForm).controls['epicgames'].patchValue(entry.url)
            break
          case EWebsites.iphone:
            this.websites(gameForm).controls['iphone'].patchValue(entry.url)
            break
          case EWebsites.itch:
            this.websites(gameForm).controls['itch'].patchValue(entry.url)
            break
          case EWebsites.gog:
            this.websites(gameForm).controls['gog'].patchValue(entry.url)
            break
          case EWebsites.steam:
            this.websites(gameForm).controls['steam'].patchValue(entry.url)
            break
          case EWebsites.ipad:
            this.websites(gameForm).controls['ipad'].patchValue(entry.url)
            break
          case EWebsites.official:
            this.websites(gameForm).controls['official'].patchValue(entry.url)
            break
          case EWebsites.twitch:
            this.websites(gameForm).controls['twitch'].patchValue(entry.url)
            break
          case EWebsites.youtube:
            this.websites(gameForm).controls['youtube'].patchValue(entry.url)
            break
          case EWebsites.facebook:
            this.websites(gameForm).controls['facebook'].patchValue(entry.url)
            break
          case EWebsites.twitter:
            this.websites(gameForm).controls['twitter'].patchValue(entry.url)
            break
          case EWebsites.instagram:
            this.websites(gameForm).controls['instagram'].patchValue(entry.url)
            break
          case EWebsites.discord:
            this.websites(gameForm).controls['discord'].patchValue(entry.url)
            break
          case EWebsites.reddit:
            this.websites(gameForm).controls['reddit'].patchValue(entry.url)
            break
          
        }
      })
    }
    
    //Involved Companies
    if(response.involvedCompanies != null && response.involvedCompanies.length > 0) {
      response.involvedCompanies.forEach((entry) => {
        let tempPlatform: Array<any> = []
        if(entry.platforms != null && entry.platforms.length > 0) {
          entry.platforms.forEach((p) => {
            tempPlatform.push(p.platformId)
          })
        }
        let tempCompany = this.formBuilder.group({
        company: entry.companyId,
        mainDeveloper: entry.developer,
        portingDeveloper: entry.porting,
        publisher: entry.publisher,
        supportingDeveloper: entry.supporting,
        platform: [tempPlatform]
        })

        this.companies(gameForm).push(tempCompany)
        console.log(this.companies(gameForm).value)
      })
    }

    // Language Support
    if(response.languageSupports != null && response.languageSupports.length > 0) {
      let audioTemp: any = []
      let interfaceTemp: any = []
      let subtitleTemp: any = []
      response.languageSupports.forEach((entry) => {
        if(entry.languageSupportTypeId === 1) {
          audioTemp.push(entry.languageId)
        }

        if(entry.languageSupportTypeId === 2) {
          subtitleTemp.push(entry.languageId)
        }

        if(entry.languageSupportTypeId === 3) {
          interfaceTemp.push(entry.languageId)
        }
      })

      this.languages(gameForm)?.get('audio')?.patchValue(audioTemp)
      this.languages(gameForm)?.get('interface')?.patchValue(interfaceTemp)
      this.languages(gameForm)?.get('subtitle')?.patchValue(subtitleTemp)
    }

  }


  createModel(gameForm: FormGroup):CreateGameDto {
    let model: CreateGameDto = {
      name: this.general(gameForm).get('name')?.value,
      story: gameForm.get('storyline')?.value,
      description: this.general(gameForm)?.get('description')?.value,
      gameStatus: this.general(gameForm)?.get('gameStatus')?.value,
      gameType: this.general(gameForm).get('updateGameType')?.value,
      parentGameId : this.general(gameForm).get('updatedGameId')?.value, 
      //gameEdition:null,
      alternativeNames: this.convertAltTitlesToDto<CreateAlternativeTitleDto>(gameForm),
      gameLocalizations: this.convertLocalizationToDto<CreateGameLocalizationDto>(gameForm),
      gameGenres:this.convertGenreToDto<CreateGameGenreDto>(gameForm),
      gameThemes:this.convertThemeToDto<CreateGameThemeDto>(gameForm),
      gameModes:this.convertGameModeToDto<CreateGameModeDto>(gameForm),
      playerPerspectives:this.convertPerspectiveToDto<CreateGamePlayerPerspectiveDto>(gameForm),
      multiplayerModes:this.convertMultiplayerModeToDto<CreateMultiplayerModeDto>(this.categorization(gameForm).get('multiplayerModes') as FormArray),
      releaseDates: this.convertReleaseDateToDto<CreateReleaseDateDto>(this.releaseDates(gameForm)),
      websites: this.convertWebsiteToDto<CreateWebsite>(gameForm),
      involvedCompanies: this.convertInvolvedCompaniesToDto<CreateInvolvedCompanyDto, CreateInvolvedCompanyPlatformDto>(this.companies(gameForm)),
      languageSupports:this.convertLanguageToDto<CreateLanguageSupportDto>(gameForm),
      cover: this.general(gameForm).get('cover')?.value,
    }

    // General game edition
    // if (this.gameEdition(gameForm).get('editionTitle')?.value!= null && this.gameEdition(gameForm).get('baseGame')?.value != null) {
    //   model.gameEdition = {
    //     editionTitle: this.gameEdition(gameForm).get('editionTitle')?.value,
    //     parentGameId: this.gameEdition(gameForm).get('baseGame')?.value,
    //   }
    // }
    return model;
  }

  updateModel(gameForm: FormGroup, gameId: number): UpdateGameDto {
    let model: UpdateGameDto = {
      id: gameId,
      name: this.general(gameForm).get('name')?.value,
      story: gameForm.get('storyline')?.value,
      description: this.general(gameForm)?.get('description')?.value,
      gameStatus: this.general(gameForm)?.get('gameStatus')?.value,
      gameType: this.general(gameForm).get('updateGameType')?.value,
      parentGameId : this.general(gameForm).get('updatedGameId')?.value, 
      //gameEdition:null,
      alternativeNames: this.convertAltTitlesToDto<UpdateAlternativeTitleDto>(gameForm),
      gameLocalizations: this.convertLocalizationToDto<UpdateGameLocalizationDto>(gameForm),
      gameGenres:this.convertGenreToDto<UpdateGameGenreDto>(gameForm),
      gameThemes:this.convertThemeToDto<UpdateGameThemeDto>(gameForm),
      gameModes:this.convertGameModeToDto<UpdateGameModeDto>(gameForm),
      playerPerspectives:this.convertPerspectiveToDto<UpdateGamePlayerPerspectiveDto>(gameForm),
      multiplayerModes:this.convertMultiplayerModeToDto<UpdateMultiplayerModeDto>(this.categorization(gameForm).get('multiplayerModes') as FormArray),
      releaseDates: this.convertReleaseDateToDto<UpdateReleaseDateDto>(this.releaseDates(gameForm)),
      websites: this.convertWebsiteToDto<UpdateWebsite>(gameForm),
      involvedCompanies: this.convertInvolvedCompaniesToDto<UpdateInvolvedCompanyDto, UpdateInvolvedCompanyPlatformDto>(this.companies(gameForm)),
      languageSupports:this.convertLanguageToDto<UpdateLanguageSupportDto>(gameForm),
      cover: this.general(gameForm).get('cover')?.value,
    }
    return model
  }

//#region Converters to Dto
  convertAltTitlesToDto<T>(gameForm: FormGroup): (Array<T> | any){
    if (this.general(gameForm).get('gameAlternativeNames')?.value.length > 0) {
      let tempArray: Array<T> = []
      this.general(gameForm).get('gameAlternativeNames')?.value.forEach((entrie) => {
        let temp = {
          type : entrie.alternativeTitleType,
          alternativeName : entrie.alternativeName
        } as T
        tempArray.push(temp)
      })
      return tempArray
    }
    return []
  }

  convertLocalizationToDto<T>(gameForm: FormGroup):(Array<T> | any) {
    if (this.localization(gameForm).value != null && this.localization(gameForm).value.length > 0) {
      let tempArray: Array<T> = []
      this.localization(gameForm).value.forEach((entrie) => {
        let temp = {
          regionId : entrie.region,
          localizedTitle : entrie.localizedTitle
        } as T
        tempArray.push(temp)
      })
      return tempArray
    }
    return []
  }

  convertGenreToDto<T>(gameForm: FormGroup):Array<T> {
    if (this.categorization(gameForm).get('genre')?.value != null ) {
      let tempArray: Array<T> = []
      this.categorization(gameForm).get('genre')?.value.forEach((x) => {
        const temp = {
          genreId: x
        } as T
        tempArray.push(temp)
      }) 
      return tempArray
    }
    return []
  }

  convertThemeToDto<T>(gameForm: FormGroup):Array<T> {
    if (this.categorization(gameForm).get('theme')?.value != null ) {
      let tempArray: Array<T> = []
      this.categorization(gameForm).get('theme')?.value.forEach((x) => {
        const temp = {
          themeId: x
        } as T
        tempArray.push(temp)
      }) 
      return tempArray
    }
    return []
  }

  convertGameModeToDto<T>(gameForm: FormGroup):Array<T> {
    if (this.categorization(gameForm).get('gameMode')?.value != null ) {
      let tempArray: Array<T> = []
      this.categorization(gameForm).get('gameMode')?.value.forEach((x) => {
        const temp = {
          gameModeId: x
        } as T
        tempArray.push(temp)
      }) 
      return tempArray
    }
    return []
  }

  convertPerspectiveToDto<T>(gameForm: FormGroup):Array<T> {
    if (this.categorization(gameForm).get('perspectives')?.value != null ) {
      let tempArray: Array<T> = []
      this.categorization(gameForm).get('perspectives')?.value.forEach((x) => {
        const temp = {
          playerPerspectiveId: x
        } as T
        tempArray.push(temp)
      }) 
      return tempArray
    }
    return []
  }

  convertInvolvedCompaniesToDto<T,K>(list: FormArray):Array<T> {
    if (list == null || list.length == 0 ) {
      return []
    }

    let convertedResults: Array<T> = []
    let arrayTempValues = list.value
    
    arrayTempValues?.forEach((x) => {
      let plaformTemp: any = []
      if(x.platform != null && x.platform.length > 0) {
        x.platform.forEach((p) => {
          plaformTemp.push({platformId: p} as K)
        })
      }
      
      let temp = {
        companyId: x.company,
        developer: x.mainDeveloper,
        porting: x.portingDeveloper,
        publisher: x.publisher,
        supporting: x.supportingDeveloper,
        platforms: plaformTemp
      } as T

      convertedResults.push(temp)
    })

    return convertedResults;
  }

  convertLanguageToDto<T>(formGroup: FormGroup): Array<T>{
    let model: Array<T> = []
    if(this.languages(formGroup)?.get('audio')?.value != null){
      this.languages(formGroup)?.get('audio')?.value.forEach((entry) => {
        let temp = {
          languageId: entry,
          languageSupportTypeId: 1
        }
        model.push(temp as T)
      })
    }

    if(this.languages(formGroup)?.get('subtitle')?.value != null){
      this.languages(formGroup)?.get('subtitle')?.value.forEach((entry) => {
        let temp = {
          languageId: entry,
          languageSupportTypeId: 2
        }
        model.push(temp as T)
      })
    }

    if(this.languages(formGroup)?.get('interface')?.value != null){
      this.languages(formGroup)?.get('interface')?.value.forEach((entry) => {
        let temp = {
          languageId: entry,
          languageSupportTypeId: 3
        }
        model.push(temp as T)
      })
    }

      return model
  }

  convertMultiplayerModeToDto<T>(list: FormArray): Array<T> {
    let convertedResults: Array<T> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
          let tempReleaseDate = {
            campaignCoop: entry.coOpCampaign,
            dropIn: entry.dropInOut,
            lanCoop: entry.lanCoOp,
            offlineCoop:entry.offlineCoOp,
            offlineCoopMax: entry.offlineCoOpMax,
            offlineMax : entry.offlineMax,
            onlineCoop: entry.onlineCoOp,
            onlineCoopMax: entry.onlineCoOpMax,
            onlineMax : entry.onlineMax,
            splitScreen: entry.offlineSpliteScreen,
            splitScreenOnline :entry.onlineSplitScreen,
            platformId : entry.platform,
          } as T
          convertedResults.push(tempReleaseDate)
      });
    }
    return convertedResults;
  }

  convertReleaseDateToDto<T>(list: FormArray): Array<T> {
    let convertedResults: Array<T> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
        entry.releases.forEach(release => {
          let tempReleaseDate = {
            platformId: entry.platform,
            date: release.date,
            regionId: release.region,
            status: release.status
          } as T

          convertedResults.push(tempReleaseDate)
        });
      });
    }
    return convertedResults;
  }

  convertWebsiteToDto<T>(formGroup: FormGroup): Array<T>{
    let websites : Array<T> = []
    Object.entries(this.websites(formGroup).value).forEach((entry) => {
      const [key, value] = entry;
      if(value != null) {
        let item = {
          url: value as string,
          category: EWebsites[key]
        } as T
        websites.push(item)
      }
    })

    return websites
  }

//#endregion Converters to Dto
  
  general(gameForm: FormGroup) {
    return gameForm.get('general') as FormGroup
  }

  releaseDates(gameForm: FormGroup) {
    return gameForm.get('releaseDates') as FormArray
  }

  localization(gameForm: FormGroup) {
    return gameForm.get('localization') as FormArray
  }

  gameEdition(gameForm: FormGroup) {
    return this.general(gameForm).get('gameEdition') as FormGroup
  }

  categorization(gameForm: FormGroup) {
    return gameForm.get('categorization') as FormGroup
  }

  companies(gameForm: FormGroup) {
    return gameForm.get('companies') as FormArray
  }

  websites(gameForm: FormGroup) {
    return gameForm.get('websites') as FormGroup
  }

  languages(gameForm: FormGroup){
    return gameForm.get('supportedLanguage') as FormGroup
  }

  searchParentGame(searchInput: string){
    const body = JSON.stringify(searchInput)
    const params = new HttpParams().set('searchInput', searchInput)
    return this.http.post<any>(this.baseUrl + '/Search', null, { params })
  }

  addGameReviewDetails(gameId, cover, name){
    this.gameReviewDetails = {
      id:gameId,
      cover: cover,
      name: name
    }
  }

  returnGameReviewDetails(){
    return this.gameReviewDetails
  }

  clearGameReviewDetails(){
    this.gameReviewDetails = null
  }

  initReviewForm(): FormGroup {
    return this.formBuilder.group({
      id:[null],
      score:[null],
      review:[null]
    })
  }

  createNewGame(model: CreateGameDto){
    return this.http.post<ServiceResult<CreateGameResponseDto>>(this.baseUrl + '/AddGame',model)
  }

  // ServiceResult<CreateCompanyDto>

  listGame(options: DataLoaderOptions){
    return this.http.post<ServiceSearchResultData<Array<GameSimpleDto>>>(this.baseUrl + '/GetAllGames', options)
  }

  getGameById(gameId:number) {
    return this.http.get<GameDetailsDto>(this.baseUrl + `/GetGame?gameId=${gameId}`)
  }

  getGameByIdForEdit(gameId) {
    return this.http.get<UpdateGameDto>(this.baseUrl + `/GetGameForEdit?gameId=${gameId}`)
  }

  updateGame(model: UpdateGameDto){
    return this.http.post<ServiceResult<UpdateGameDto>>(this.baseUrl + '/UpdateGame',model)
  }

  addUserReview(model: AddUserReviewDto){
    return this.http.post<ServiceResult<AddUserReviewDto>>(this.baseUrl + '/AddUserReview',model)
  }

  getAllGameUserReviews(gameId:number) {
    return this.http.get<GameUserReviewsDto>(this.baseUrl + `/GetAllGameUserReviews?gameId=${gameId}`)
  }
}
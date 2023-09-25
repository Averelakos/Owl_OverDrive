import { Injectable } from "@angular/core";
import { FormArray, FormBuilder, FormGroup } from "@angular/forms";
import { environment } from "src/environments/environment";
import { HttpClient, HttpParams} from "@angular/common/http";
import { CreateGameDto, CreateGameGenreDto, CreateGameLocalizationDto, CreateGameModeDto, CreateGamePlayerPerspectiveDto, CreateGameThemeDto, CreateImageDto, CreateInvolvedCompanyDto, CreateLanguageSupportDto, CreateMultiplayerModeDto, CreateReleaseDateDto, CreateWebsite } from "../types/game/create-game";
import { GameSimpleDto } from "../types/game/GameSimpleDto";
import { ServiceSearchResultData } from "../types/service-results/service-searc-result-data";
import { DataLoaderOptions } from "../types/data-loader/data-loader-options";
import { BehaviorSubject } from "rxjs";
import { GameDetailsDto } from "../types/game/game-details-dto";
import { UpdateGameDto } from "../types/game/update-game";
import { EWebsites } from "src/app/core/enums/enum-websites";
import { ServiceResult } from "../types/service-results/service-result";


@Injectable()
export class GameService{
  uri: string = 'Game'
  baseUrl = environment.apiUrl+this.uri;
  searchString: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null)
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

  populateForm = (gameForm: FormGroup, response: UpdateGameDto) => {
    this.general(gameForm).get('name')?.patchValue(response.name)
    this.general(gameForm)?.get('description')?.patchValue(response.description)
    this.general(gameForm)?.get('gameStatus')?.patchValue(response.gameStatus)
    this.general(gameForm).get('updateGameType')?.patchValue(response.gameType)
    this.general(gameForm).get('updatedGameId')?.patchValue(response.parentGameId)
    this.general(gameForm).get('cover')?.patchValue(response.cover)

    gameForm.get('storyline')?.patchValue(response.story)
  }


  //#region Create

  createModel(gameForm: FormGroup):CreateGameDto {
    let model: CreateGameDto = {
      name: this.general(gameForm).get('name')?.value,
      story: gameForm.get('storyline')?.value,
      description: this.general(gameForm)?.get('description')?.value,
      gameStatus: this.general(gameForm)?.get('gameStatus')?.value,
      gameType: this.general(gameForm).get('updateGameType')?.value,
      parentGameId : this.general(gameForm).get('updatedGameId')?.value, 
      //gameEdition:null,
      alternativeNames: [],
      gameLocalizations: [],
      gameGenres:[],
      gameThemes:[],
      gameModes:[],
      playerPerspectives:[],
      multiplayerModes:this.converToCreatemultiplayerModeDto(this.categorization(gameForm).get('multiplayerModes') as FormArray),
      releaseDates: this.converToCreateReleaseDateDto(this.releaseDates(gameForm)),
      websites: this.convertToListCreateWebsiteDto(gameForm),
      involvedCompanies: [],
      languageSupports:[],
      cover: this.general(gameForm).get('cover')?.value,
    }


    // General game edition
    // if (this.gameEdition(gameForm).get('editionTitle')?.value!= null && this.gameEdition(gameForm).get('baseGame')?.value != null) {
    //   model.gameEdition = {
    //     editionTitle: this.gameEdition(gameForm).get('editionTitle')?.value,
    //     parentGameId: this.gameEdition(gameForm).get('baseGame')?.value,
    //   }
    // }

    // General game alternative name
    if (this.general(gameForm).get('gameAlternativeNames')?.value.length > 0) {
      model.alternativeNames = this.general(gameForm).get('gameAlternativeNames')?.value
    }

    // Localization
    if (this.localization(gameForm).value != null && this.localization(gameForm).value.length > 0) {
      this.localization(gameForm).value.forEach((entrie) => {
        let temp: CreateGameLocalizationDto = {
          regionId : entrie.region,
          localizedTitle : entrie.localizedTitle
        }
        model.gameLocalizations.push(temp)
      })
    }

    if (this.categorization(gameForm).get('genre')?.value != null ) {
      this.categorization(gameForm).get('genre')?.value.forEach((x) => {
        const temp: CreateGameGenreDto = {
          genreId: x
        }
        model.gameGenres.push(temp)
      }) 
    }

    if (this.categorization(gameForm).get('theme')?.value != null ) {
      this.categorization(gameForm).get('theme')?.value.forEach((x) => {
        const temp: CreateGameThemeDto = {
          themeId: x
        }
        model.gameThemes.push(temp)
      }) 
    }

    if (this.categorization(gameForm).get('gameMode')?.value != null ) {
      this.categorization(gameForm).get('gameMode')?.value.forEach((x) => {
        const temp: CreateGameModeDto = {
          gameModeId: x
        }
        model.gameModes.push(temp)
      }) 
    }

    if (this.categorization(gameForm).get('perspectives')?.value != null ) {
      this.categorization(gameForm).get('perspectives')?.value.forEach((x) => {
        const temp: CreateGamePlayerPerspectiveDto = {
          playerPerspectiveId: x
        }
        model.playerPerspectives.push(temp)
      }) 
    }

    //Involved Companies
    if(this.companies(gameForm).value.length > 0) {
      model.involvedCompanies = this.convertToCreateInvolvedCompaniesModelDto(this.companies(gameForm) as FormArray)
    }

    //Languages
    model.languageSupports = this.convertToListCreatelanguageDto(gameForm)


    return model;
  }

  updateModel(gameForm: FormGroup, gameId: number):UpdateGameDto {
    let model: UpdateGameDto = {
      id: gameId,
      name: this.general(gameForm).get('name')?.value,
      story: gameForm.get('storyline')?.value,
      description: this.general(gameForm)?.get('description')?.value,
      gameStatus: this.general(gameForm)?.get('gameStatus')?.value,
      gameType: this.general(gameForm).get('updateGameType')?.value,
      parentGameId : this.general(gameForm).get('updatedGameId')?.value, 
      //gameEdition:null,
      
      cover: this.general(gameForm).get('cover')?.value,
    }

    return model;
  }

  convertToListCreatelanguageDto(formGroup: FormGroup): Array<CreateLanguageSupportDto>{
    let model: Array<CreateLanguageSupportDto> = []
    if(this.languages(formGroup)?.get('audio')?.value != null){
      this.languages(formGroup)?.get('audio')?.value.forEach((entry) => {
        let temp:CreateLanguageSupportDto = {
          languageId: entry,
          languageSupportTypeId: 1
        }
        model.push(temp)
      })
    }

    if(this.languages(formGroup)?.get('subtitle')?.value != null){
      this.languages(formGroup)?.get('subtitle')?.value.forEach((entry) => {
        let temp:CreateLanguageSupportDto = {
          languageId: entry,
          languageSupportTypeId: 2
        }
        model.push(temp)
      })
    }

    if(this.languages(formGroup)?.get('interface')?.value != null){
      this.languages(formGroup)?.get('interface')?.value.forEach((entry) => {
        let temp:CreateLanguageSupportDto = {
          languageId: entry,
          languageSupportTypeId: 3
        }
        model.push(temp)
      })
    }

      return model
  }

  convertToListLanguage<T>(formGroup: FormGroup): Array<T>{
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

  convertToListCreateWebsiteDto(formGroup: FormGroup){
    let websites : Array<CreateWebsite> = []
    Object.entries(this.websites(formGroup).value).forEach((entry) => {
      const [key, value] = entry;
      if(value != null) {
        console.log(EWebsites[key], value)
        let item: CreateWebsite = {
          url: value as string,
          category: EWebsites[key]
        }
        websites.push(item)
      }
    })

    return websites
  }

  convertToCreateWebsiteDto(formGroup: FormGroup) {
    if(this.websites(formGroup).get('steam')?.value != null) {
      let item: CreateWebsite = {
        url:this.websites(formGroup).get('steam')?.value,
        category: EWebsites.steam
      }
    }    
  }


  convertToCreateInvolvedCompaniesModelDto(list: FormArray) {
    let convertedResults: Array<CreateInvolvedCompanyDto> = []
    let arrayTempValues = list.value
    debugger
    arrayTempValues?.forEach((x) => {
      let temp: CreateInvolvedCompanyDto = {
        companyId: x.company,
        developer: x.mainDeveloper,
        porting: x.portingDeveloper,
        publisher: x.publisher,
        supporting: x.supportingDeveloper,
        platform: []
      }

      convertedResults.push(temp)
    })

    return convertedResults;
  }

  converToCreatemultiplayerModeDto(list: FormArray) {
    let convertedResults: Array<CreateMultiplayerModeDto> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
          let tempReleaseDate: CreateMultiplayerModeDto = {
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
          }
          convertedResults.push(tempReleaseDate)
      });
    }
    return convertedResults;
  }

  converToCreateReleaseDateDto(list: FormArray) {
    let convertedResults: Array<CreateReleaseDateDto> = []
    let arrayTempValues = list.value
    if (arrayTempValues != null && arrayTempValues.length > 0) {
      arrayTempValues.forEach((entry) => {
        entry.releases.forEach(release => {
          let tempReleaseDate: CreateReleaseDateDto = {
            platformId: entry.platform,
            date: release.date,
            regionId: release.region,
            status: release.status
          }

          convertedResults.push(tempReleaseDate)
        });
      });
    }
    return convertedResults;
  }

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

  createNewGame(model: CreateGameDto){
    return this.http.post<any>(this.baseUrl + '/AddGame',model)
  }

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

}
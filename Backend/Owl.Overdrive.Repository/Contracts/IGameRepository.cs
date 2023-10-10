using Owl.Overdrive.Domain.Entities.Game;

namespace Owl.Overdrive.Repository.Contracts
{
    public interface IGameRepository
    {
        /// <summary>
        /// Queries the game.
        /// </summary>
        /// <returns></returns>
        IQueryable<Game> QueryGame();
        /// <summary>
        /// Inserts the specified game.
        /// </summary>
        /// <param name="company">The company.</param>
        /// <returns></returns>
        Task<Game> Insert(Game company);
        /// <summary>
        /// Searches the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        Task<List<Game>> Search(string input);
        /// <summary>
        /// Gets the list of games.
        /// </summary>
        /// <returns></returns>
        Task<List<Game>> GetList();
        /// <summary>
        /// Gets the game by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Game?> GetGameByIdNoTacking(long id);
        Task<Game?> GetById(long id);
        Task<Game> UpdateGame(Game game);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveChangesAsync();
        Task RemoveRangeAltTitles(List<AlternativeName> dbItems);
        Task RemoveRangeLocalizations(List<Localization> dbItems);
        Task RemoveRangeReleaseDates(List<ReleaseDate> dbItems);
        Task RemoveRangeMultiplayerModes(List<MultiplayerMode> dbItems);
        Task RemoveRangeGameThemes(List<GameTheme> dbItems);
        Task RemoveRangeGameGenres(List<GameGenre> dbItems);
        Task RemoveRangeGameModes(List<GameGameMode> dbItems);
        Task RemoveRangeGamePerspectives(List<GamePlayerPerspective> dbItems);
        Task RemoveRangeWebsites(List<Website> dbItems);
        Task RemoveRangeInvolvedCompanies(List<InvolvedCompany> dbItems);
        Task RemoveRangeSupportedLanguagess(List<LanguageSupport> dbItems);

        #region User Review
        Task<UserReview> AddUserReview(UserReview dbItem);
        Task<List<UserReview>> GetGameUserReviews(long gameId);
        #endregion User Review
    }
}
